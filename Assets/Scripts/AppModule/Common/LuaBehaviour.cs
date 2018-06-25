using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class LuaBehaviour : ViewComponent
{
    public string luaClassName = null;
    public Dictionary<string, string> luaVariable;

    protected LuaTable m_currentLuaTable = null;

    protected virtual void Awake()
    {
        if (luaClassName == null | luaClassName.Length == 0)
        {
            luaClassName = gameObject.name;
        }

        m_currentLuaTable = LuaManager.Instance.PCallTableLuaFunction(luaClassName + ".create", gameObject);
        CallLuaFunction("awake");
    }

    // Use this for initialization
    protected virtual void Start()
    {
        CallLuaFunction("start");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CallLuaFunction("update");
    }
    protected virtual void Destroy()
    {
        CallLuaFunction("destroy");
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Dispose();
            m_currentLuaTable = null;
        }
    }

    protected virtual void CallLuaFunction(string luaFunctionName)
    {
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Call(luaFunctionName, m_currentLuaTable);
        }
    }
}
