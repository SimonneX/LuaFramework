using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResourcesManager : Manager
{

    private static ResourcesManager s_instance;
    public static ResourcesManager Instance
    {
        get
        {
            return s_instance;
        }
    }


    protected Dictionary<string, AssetBundle> bundleMap = new Dictionary<string, AssetBundle>();

    public GameObject GetResourcesObject(string relativePath)
    {
        // 如果是编辑器的话直接返回resources下的资源
        if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
        {
            return Resources.Load<GameObject>(relativePath);
        }

        return GetResourcesObjectFromAssetBundle(relativePath);
    }

    /// <summary>
    /// 从AssetBundl文件中加载资源
    /// </summary>
    /// <param name="relativePath">资源路径</param>
    /// <param name="cacheBundle">是否需要缓存assetbundle，默认是true</param>
    /// <returns></returns>
    public GameObject GetResourcesObjectFromAssetBundle(string relativePath, bool cacheBundle = true)
    {
        string bundlePath = Path.Combine(Application.streamingAssetsPath, Path.GetDirectoryName(relativePath));
        AssetBundle bundle = null;
        if (bundleMap.ContainsKey(bundlePath))
        {
            bundle = bundleMap[bundlePath];
        }
        else
        {
            bundle = AssetBundle.LoadFromFile(bundlePath);
            if (bundle == null)
            {
                Debug.LogWarning("Failed to load AssetBundle >> " + bundlePath);
                return null;
            }
            if (cacheBundle)
            {
                bundleMap.Add(bundlePath, bundle);
            }
        }

        GameObject obj = bundle.LoadAsset<GameObject>(Path.GetFileName(relativePath));
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

    protected override void Awake()
    {
        base.Awake();
        s_instance = this;
    }

    void Start()
    {
    }

    protected ResourcesUpdateData updateStatusData = new ResourcesUpdateData();
    protected bool m_bCheckRes = false;
    public void CheckResources()
    {
        m_bCheckRes = true;
    }
    void Update()
    {
        if (m_bCheckRes)
        {
            updateStatusData.percent += Time.deltaTime;
            SendNotification(NotificationDefine.RESOURCES_UPDATE_PERCENT, updateStatusData);
            if (updateStatusData.percent >= 1.0f)
            {
                SendNotification(NotificationDefine.RESOURCES_UPDATE_PERCENT, updateStatusData);
                SendNotification(NotificationDefine.RESOURCES_UPDATE_FINISH);
                m_bCheckRes = false;
            }
        }
    }
}
