using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
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

    void Update()
    {

    }

    void ShowDebugView()
    {
        if (!enabledDebugView)
            return;

        Instantiate(ResourcesManager.Instance.GetResourcesObject("Prefabs/Common/DebugViewCanvas"));
    }
}
