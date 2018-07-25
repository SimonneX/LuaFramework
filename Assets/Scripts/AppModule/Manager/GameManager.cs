using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    public const string CDN_URL = "http://127.0.0.1:3000";
    public bool enabledDebugView = false;
    private static GameManager s_instance;
    public static GameManager Instance
    {
        get
        {
            return s_instance;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        s_instance = this;
    }
    void Start()
    {
        ApplicationFacade.Instance.StartUp();
        ShowDebugView();
    }

    void ShowDebugView()
    {
        if (!enabledDebugView)
            return;

        Instantiate(ResourcesManager.Instance.GetResourcesObject("prefabs/common/DebugViewCanvas"));
    }
}
