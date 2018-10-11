using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DebugView : MonoBehaviour
{
    public const string PREFAB_PATH = "static/DebugViewCanvas";
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
        yield return null;
    }
}
