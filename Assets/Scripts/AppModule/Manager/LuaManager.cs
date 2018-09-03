using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using System.IO;

public class LuaManager : Manager<LuaManager>
{
    public const string LuaPath = "Lua";
    public const string ToLuaPath = "Lua/ToLua";
    private LuaState m_luaState = null;
    private LuaResLoader m_luaResLoader = null;
    // Use this for initialization

    public void Init()
    {
        m_luaResLoader = new LuaResLoader();
        m_luaState = new LuaState();
        InitLuaPath();
        m_luaState.Start();
        LuaBinder.Bind(m_luaState);
    }

    public void StartMain()
    {
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

    public void PCallVoidLuaFunction(string functionName, params object[] parms)
    {
        if (m_luaState == null)
            return;
        LuaFunction func = m_luaState.GetFunction(functionName);
        if (func == null)
            return;
        func.BeginPCall();
        for (int i = 0; i < parms.Length; ++i)
        {
            func.Push(parms[i]);
        }
        func.PCall();
        func.EndPCall();
        func.Dispose();
    }

    public LuaTable PCallTableLuaFunction(string functionName, params object[] parms)
    {
        if (m_luaState == null)
            return null;

        LuaFunction func = m_luaState.GetFunction(functionName);
        if (func == null)
            return null;
        func.BeginPCall();
        for (int i = 0; i < parms.Length; ++i)
        {
            func.Push(parms[i]);
        }
        func.PCall();
        LuaTable t = func.CheckLuaTable();
        func.EndPCall();
        func.Dispose();
        return t;
    }

    public bool AddSearchPath(string searchPath)
    {
        return LuaFileUtils.Instance.AddSearchPath(searchPath);
    }

    public bool RemoveSearchPath(string searchPath)
    {
        return LuaFileUtils.Instance.RemoveSearchPath(searchPath);
    }

    protected override void Awake()
    {
        base.Awake();
        s_instance = this;
    }

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (m_luaState != null)
        {
            m_luaState.CheckTop();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

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

#if UNITY_EDITOR
        m_luaState.AddSearchPath(Path.Combine(Application.dataPath, LuaPath));
#endif
        m_luaState.AddSearchPath(Path.Combine(Application.persistentDataPath, LuaPath));
        m_luaState.AddSearchPath(Path.Combine(Application.persistentDataPath, ToLuaPath));
        m_luaState.AddSearchPath(Path.Combine(Application.streamingAssetsPath, LuaPath));
        m_luaState.AddSearchPath(Path.Combine(Application.streamingAssetsPath, ToLuaPath));
    }
}
