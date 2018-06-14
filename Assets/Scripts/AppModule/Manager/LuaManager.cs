using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class LuaManager : Manager
{

    private static LuaManager s_instance;
    public static LuaManager Instance
    {
        get
        {
            return s_instance;
        }
    }
    private LuaState m_luaState = null;
    private LuaResLoader m_luaResLoader = null;
    // Use this for initialization

    public void Init()
    {
        m_luaResLoader = new LuaResLoader();
        m_luaState = new LuaState();
        m_luaState.Start();
        LuaBinder.Bind(m_luaState);

        InitLuaPath();
        m_luaState.Require("app/main");
    }

    public void Reset()
    {
        if (m_luaState == null)
            return;

        m_luaState.Dispose();
        m_luaState = null;
        Init();
    }

    protected override void Awake()
    {
        base.Awake();
        s_instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_luaState != null)
        {
            m_luaState.CheckTop();
        }
    }

    void OnDestroy()
    {
        if (m_luaState != null)
        {
            m_luaState.Dispose();
            m_luaState = null;
        }
    }

    protected void InitLuaPath()
    {
        if (m_luaState == null)
        {
            Debug.LogWarning("LuaManager >> InitLuaPath >> m_luaState is null");
            return;
        }
        m_luaState.AddSearchPath(Application.dataPath + "/Lua");
    }
}
