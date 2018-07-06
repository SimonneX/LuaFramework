using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DebugView : MonoBehaviour
{
    public GameObject debugPanel;
    public Toggle showToggle;

    public Text textInfo;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        RefreshDebugViewState();
        InitInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitInfo()
    {
        string strInfo = "Platform: " + Application.platform + "\n";
        strInfo = strInfo + "Language: " + Application.systemLanguage + "\n";
        strInfo = strInfo + "Version: " + Application.version + "\n";
        textInfo.text = strInfo;
    }

    public void OnToggleDebugView()
    {
        RefreshDebugViewState();
    }

    public void RefreshDebugViewState()
    {
        debugPanel.active = showToggle.isOn;
    }

    public void OnClickApplicationPathInfo()
    {
        string pathInfo = "DataPath: " + Application.dataPath + "\n";
        pathInfo = pathInfo + "PersistentDataPath: " + Application.persistentDataPath + "\n";
        pathInfo = pathInfo + "TemporaryCachePath: " + Application.temporaryCachePath + "\n";
        pathInfo = pathInfo + "StreamingAssetBundlePath: " + Application.streamingAssetsPath + "\n";
        Debug.Log(pathInfo);
    }

    public void OnClickTestHttp()
    {
        Debug.Log("OnClickTestHttp");
    }

    public void OnClickTestDownload()
    {
        StartCoroutine(StartDownloadFile());
    }

    IEnumerator StartDownloadFile()
    {
        for (int i = 0; i < 40; ++i)
        {
            WWW wd = new WWW("https://www.baidu.com/img/bd_logo1.png");
            yield return wd;
            while (!wd.isDone)
            {
                Debug.Log("download:" + wd.progress + "%");
                yield return null;
            }

            string fullPathFile = Application.persistentDataPath + "/" + i + ".png";
            File.WriteAllBytes(fullPathFile, wd.bytes);
            Debug.Log("SaveFileTo:" + fullPathFile);
        }
        yield return null;
    }
}
