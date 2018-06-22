using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class LuaBehaviour : ViewComponent
{
    public string luaClassName = null;

    protected LuaTable m_currentLuaTable = null;

    protected virtual void Awake()
    {
        if (luaClassName == null | luaClassName.Length == 0)
        {
            luaClassName = gameObject.name;
        }

        m_currentLuaTable = LuaManager.Instance.PCallTableLuaFunction(luaClassName + ".create");
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Call("awake");
        }
    }

    // Use this for initialization
    protected virtual void Start()
    {
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Call("start");
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Call("update");
        }
    }
    protected virtual void Destroy()
    {
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Call("destroy");
        }
    }
}
