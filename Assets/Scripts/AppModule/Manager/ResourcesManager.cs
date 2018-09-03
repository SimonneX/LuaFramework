/*
 * @Author: simonne.xu 
 * @Date: 2018-08-02 15:24:40 
 * @Last Modified by: simonne.xu
 * @Last Modified time: 2018-08-15 16:39:40
 * @Description: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResourcesManager : Manager<ResourcesManager>
{
    public enum LoadModeType
    {
        FromAssetBundle,
        FromResources
    }
    /// <summary>
    /// 读取资源的目录【只有编辑器模式下此选项才有效】
    /// 如果选择Resources默认跳过热更
    /// </summary>¡
    public LoadModeType loadMode = LoadModeType.FromAssetBundle;

    protected Dictionary<string, AssetBundle> bundleMap = new Dictionary<string, AssetBundle>();

    protected List<string> m_searchPathList = new List<string>();

    protected override void Awake()
    {
        base.Awake();

        s_instance = this;
    }

    protected override void Start()
    {
        base.Start();
    }

    public bool AddSearchPath(string searchPath, bool insertFront = false)
    {
        if (m_searchPathList.IndexOf(searchPath) >= 0)
        {
            return false;
        }

        if (insertFront)
        {
            m_searchPathList.Insert(0, searchPath);
        }
        else
        {
            m_searchPathList.Add(searchPath);
        }
        return true;
    }

    public bool RemoveSearchPath(string searchPath)
    {
        return m_searchPathList.Remove(searchPath);
    }

    public string GetFileFullPath(string fileName)
    {
        for (int i = 0; i < m_searchPathList.Count; ++i)
        {
            string fileFullPath = Path.Combine(m_searchPathList[i], fileName);
            if (File.Exists(fileFullPath))
            {
                return fileFullPath;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取资源对象
    /// </summary>
    /// <param name="relativePath"></param>
    /// <returns></returns>
    public T GetResourcesObject<T>(string relativePath) where T : Object
    {
        T resObj = null;

        if (Application.isEditor && loadMode == LoadModeType.FromResources)
        {
            return GetResourcesObjectFromResources<T>(relativePath);
        }

        // 正常优先从AssetBundle读取，没有的话再去Resources目录找
        resObj = GetResourcesObjectFromAssetBundle<T>(relativePath);
        if (resObj == null)
        {
            Debug.Log(relativePath + ", AseetBundle not Found,Try Get From Resources Folder");
            resObj = GetResourcesObjectFromResources<T>(relativePath);
        }

        return resObj;
    }

    /// <summary>
    /// 从Resources目录直接读取资源
    /// </summary>
    /// <param name="relativePath">资源路径</param>
    /// <returns></returns>
    public T GetResourcesObjectFromResources<T>(string relativePath) where T : Object
    {
        return Resources.Load<T>(relativePath);
    }

    /// <summary>
    /// 从AssetBundl文件中加载资源
    /// </summary>
    /// <param name="relativePath">资源路径</param>
    /// <param name="cacheBundle">是否需要缓存assetbundle，默认是true</param>
    /// <returns></returns>
    public T GetResourcesObjectFromAssetBundle<T>(string relativePath, bool cacheBundle = true) where T : Object
    {
        string bundlePath = GetFileFullPath(Path.GetDirectoryName(relativePath));
        if (bundlePath == null)
        {
            return null;
        }
        AssetBundle bundle = null;
        if (bundleMap.ContainsKey(bundlePath))
        {
            bundle = bundleMap[bundlePath];
        }
        else
        {
            if (!File.Exists(bundlePath))
            {
                return null;
            }
            bundle = AssetBundle.LoadFromFile(bundlePath);
            if (bundle == null)
            {
                // Debug.LogWarning("Failed to load AssetBundle >> " + bundlePath);
                return null;
            }
            if (cacheBundle)
            {
                bundleMap.Add(bundlePath, bundle);
            }
        }

        T obj = bundle.LoadAsset<T>(Path.GetFileName(relativePath));
        if (!cacheBundle)
        {
            bundle.Unload(false);
        }
        return obj;
    }

    /// <summary>
    /// 清理AssetBundle的缓存
    /// </summary>
    public void ClearAssetBundleCaches()
    {
        foreach (KeyValuePair<string, AssetBundle> pair in bundleMap)
        {
            pair.Value.Unload(true);
        }
        bundleMap.Clear();
    }

    protected ResourcesUpdateData updateStatusData = new ResourcesUpdateData();
    protected bool m_bCheckRes = false;
    public void CheckResources()
    {
        updateStatusData.Reset();
        if (Application.isEditor && loadMode == LoadModeType.FromResources)
        {
            StartCoroutine(SkipCheckUpdateFiles());
        }
        else
        {
            float time = Time.realtimeSinceStartup;
            float size = 0;

            List<DownloadFile> list = new List<DownloadFile>();
            // list.Add(new DownloadFile("https://speed.hetzner.de/100MB.bin", Path.Combine(Application.persistentDataPath, "test1.bin")));
            list.Add(new DownloadFile("https://image.baidu.com/search/down?tn=download&word=download&ie=utf8&fr=detail&url=https%3A%2F%2Ftimgsa.baidu.com%2Ftimg%3Fimage%26quality%3D80%26size%3Db9999_10000%26sec%3D1535005781611%26di%3Decfa16c783fec6a3eee60d0cb4eee654%26imgtype%3D0%26src%3Dhttp%253A%252F%252Fatt.bbs.duowan.com%252Fforum%252F201209%252F28%252F075324wcewb8zwgb1pgbg0.jpg&thumburl=https%3A%2F%2Fss1.bdstatic.com%2F70cFvXSh_Q1YnxGkpoWK1HF6hhy%2Fit%2Fu%3D3206931758%2C4276788165%26fm%3D26%26gp%3D0.jpg", Path.Combine(Application.persistentDataPath, "test.jpg")));

            FileDownloader downloader = FileDownloader.DownloadFiles(list);
            downloader.onDownloadStateChanged = (FileDownloader dl, DownloadState state) =>
            {
                if (state == DownloadState.NetworkError)
                {
                    ApplicationFacade.Instance.SendNotification(NotificationDefine.SHOW_ALERT_VIEW, new AlertViewData(dl.error));
                }
                else if (state == DownloadState.HttpError)
                {
                    ApplicationFacade.Instance.SendNotification(NotificationDefine.SHOW_ALERT_VIEW, new AlertViewData("responseCode:" + dl.responseCode));
                }
                else if (state == DownloadState.Finish)
                {
                    updateStatusData.SetPercent(1.0f);
                    SendNotification(NotificationDefine.CHECK_RESOURCES_STATUS_UPDATE, updateStatusData);
                    Destroy(dl);
                }
            };
            downloader.onDownloadedSizeChanged = (FileDownloader dl, float downloadedSize) =>
            {
                float totalSize = 393;
                updateStatusData.SetPercent(downloadedSize / totalSize);
                if ((Time.realtimeSinceStartup - time) > 1.0f)
                {
                    float speed = (downloader.downloadedSize - size) / (Time.realtimeSinceStartup - time);
                    updateStatusData.SetSpeed(speed);
                    time = Time.realtimeSinceStartup;
                    size = downloader.downloadedSize;
                }
                SendNotification(NotificationDefine.CHECK_RESOURCES_STATUS_UPDATE, updateStatusData);
            };
        }
    }

    /// <summary>
    /// 跳过热更
    /// </summary>
    /// <returns></returns>
    IEnumerator SkipCheckUpdateFiles()
    {
        Debug.LogWarning("ResourcesManager >> LoadFromResources >> skipCheckResources");
        yield return new WaitForSeconds(0.1f);
        updateStatusData.SetPercent(1.0f);
        SendNotification(NotificationDefine.CHECK_RESOURCES_STATUS_UPDATE, updateStatusData);
        yield return null;
    }

    protected override void Update()
    {
        base.Update();
    }
}
