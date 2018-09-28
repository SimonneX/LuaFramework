using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//InvalidOperationException: UnityWebRequest has already been sent and its URL cannot be altered
public enum DownloadState
{
    None = 1 << 0,
    Downloading,
    NetworkError,
    HttpError,
    Finish
};

public class DownloadFile
{
    public string url;
    public string savePath;
    public DownloadState state;

    public DownloadFile(string url, string savePath)
    {
        this.url = url;
        this.savePath = savePath;
        state = DownloadState.None;
    }

    public void ChangeStateTo(DownloadState st)
    {
        state = st;
    }
}
public class FileDownloader : MonoBehaviour
{
    /// <summary>
    /// 下载列表
    /// </summary>
    public List<DownloadFile> downloadList;
    /// <summary>
    /// 当前下载状态
    /// </summary>
    public DownloadState state = DownloadState.None;
    /// <summary>
    /// 当前已下载的大小
    /// </summary>
    public float downloadedSize = 0.0f;
    [HideInInspector]
    public long responseCode = -1;
    [HideInInspector]
    public string error = null;

    /// <summary>
    /// 下载状态变化
    /// </summary>
    /// <param name="downloader"></param>
    /// <param name="st"></param>
    public delegate void OnDownloadStateChangedDelegate(FileDownloader downloader, DownloadState st);
    public OnDownloadStateChangedDelegate onDownloadStateChanged;
    /// <summary>
    /// 下载大小变化
    /// </summary>
    /// <param name="downloader"></param>
    /// <param name="downloadedSize"></param>
    public delegate void OnDownloadedSizeChangedDelegate(FileDownloader downloader, float downloadedSize);
    public OnDownloadedSizeChangedDelegate onDownloadedSizeChanged;
    /// <summary>
    /// 单个文件下载开始/结束
    /// </summary>
    /// <param name="url"></param>
    public delegate void OnFileDownloadDelegate(FileDownloader downloader, string url);
    public OnFileDownloadDelegate onFileDownloadStart;
    public OnFileDownloadDelegate onFileDownloadFinish;

    protected const string OBJ_NAME = "FileDownloader";

    /// <summary>
    /// No timeout is applied when timeout is set to 0
    /// </summary>
    protected int m_timeout = 0;
    public int timeout
    {
        get
        {
            return m_timeout;
        }
        set
        {
            m_timeout = value;
        }
    }
    protected float m_downloadedFileSize = 0.0f;

    protected int m_retrytimes = 3;

    public int retryTimes
    {
        get
        {
            return m_retrytimes;
        }
        set
        {
            m_retrytimes = value;
        }
    }
    protected int m_currentRetryTimes = 0;

    protected UnityWebRequest m_uwr = null;

    /// <summary>
    /// 下载多个文件
    /// </summary>
    /// <param name="fileList"></param>
    /// <returns></returns>
    static public FileDownloader DownloadFiles(List<DownloadFile> fileList)
    {
        GameObject obj = GameObject.Find(OBJ_NAME);
        if (obj == null)
        {
            obj = new GameObject();
            obj.name = OBJ_NAME;
        }

        FileDownloader downloader = obj.AddComponent<FileDownloader>();
        downloader.downloadList = fileList;

        return downloader;
    }

    /// <summary>
    /// 下载单个文件
    /// </summary>
    /// <param name="url"></param>
    /// <param name="localPath"></param>
    /// <returns></returns>
    static public FileDownloader DownloadFile(string url, string localPath)
    {
        GameObject obj = GameObject.Find(OBJ_NAME);
        if (obj == null)
        {
            obj = new GameObject();
            obj.name = OBJ_NAME;
        }

        FileDownloader downloader = obj.AddComponent<FileDownloader>();
        downloader.InsertDownloadFile(url, localPath);
        return downloader;
    }

    public void InsertDownloadFile(string url, string localPath)
    {
        if (downloadList == null)
        {
            downloadList = new List<DownloadFile>();
        }
        downloadList.Add(new DownloadFile(url, localPath));
    }

    /// <summary>
    /// 恢复下载
    /// </summary>
    public void Resume()
    {
        ChangeStateTo(DownloadState.Downloading);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ChangeStateTo(DownloadState.None);
        if (downloadList == null || downloadList.Count == 0)
            return;

        ChangeStateTo(DownloadState.Downloading);
    }

    void Update()
    {
        if (state == DownloadState.Downloading && m_uwr != null && !m_uwr.isDone)
        {
            downloadedSize = m_downloadedFileSize + m_uwr.downloadedBytes / 1024;
            if (onDownloadedSizeChanged != null)
            {
                onDownloadedSizeChanged(this, downloadedSize);
            }
        }
    }

    void ChangeStateTo(DownloadState st)
    {
        state = st;
        Debug.Log("ChangeStateTo:" + st.ToString());
        switch (state)
        {
            case DownloadState.None:
                {
                    m_downloadedFileSize = 0.0f;
                }
                break;
            case DownloadState.Downloading:
                {

                    string filesStr = "FileDownloader >> DownloadList:\n";
                    for (int i = 0; i < downloadList.Count; ++i)
                    {
                        filesStr += downloadList[i].url + "\n";
                    }
                    Debug.Log(filesStr);

                    error = null;
                    responseCode = -1;
                    downloadedSize = 0.0f;
                    StartCoroutine(StartDownloadFile());
                }
                break;
            case DownloadState.NetworkError:
                {
                    error = m_uwr.error;
                }
                break;
            case DownloadState.HttpError:
                {
                    responseCode = m_uwr.responseCode;
                }
                break;
            default:
                break;
        }

        if (onDownloadStateChanged != null)
        {
            onDownloadStateChanged(this, st);
        }
    }

    IEnumerator StartDownloadFile()
    {
        while (state == DownloadState.Downloading && downloadList.Count > 0)
        {
            DownloadFile file = downloadList[0];
            file.state = DownloadState.Downloading;
            Debug.Log("FileDownloader >> Start Download:" + file.url);
            if (onFileDownloadStart != null)
            {
                onFileDownloadStart(this, file.url);
            }

            m_uwr = new UnityWebRequest(file.url);
            m_uwr.downloadHandler = new DownloadHandlerFile(file.savePath);
            m_uwr.timeout = m_timeout;
            yield return m_uwr.SendWebRequest();

            if (m_uwr.isNetworkError || m_uwr.isHttpError)
            {
                if (m_currentRetryTimes < m_retrytimes)
                {
                    ++m_currentRetryTimes;
                    Debug.Log("retry_time:" + m_currentRetryTimes);
                    continue;
                }
                m_currentRetryTimes = 0;
                if (m_uwr.isNetworkError)
                {
                    file.ChangeStateTo(DownloadState.NetworkError);
                    ChangeStateTo(DownloadState.NetworkError);
                    break;
                }

                if (m_uwr.isHttpError)
                {
                    file.ChangeStateTo(DownloadState.HttpError);
                    ChangeStateTo(DownloadState.HttpError);
                    break;
                }
            }

            if (m_uwr.isDone)
            {
                m_currentRetryTimes = 0;
                file.state = DownloadState.Finish;
                m_downloadedFileSize += (m_uwr.downloadedBytes / 1024);
                if (onFileDownloadFinish != null)
                {
                    onFileDownloadFinish(this, file.url);
                }

                downloadList.RemoveAt(0);
                yield return null;
            }
        }

        if (downloadList.Count == 0)
        {
            m_uwr.Dispose();
            ChangeStateTo(DownloadState.Finish);
        }

        yield return null;
    }
}
