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

        m_currentLuaTable = LuaManager.Instance.PCallTableLuaFunction(luaClassName + ".create", gameObject);
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Call("awake", m_currentLuaTable);
        }
    }

    // Use this for initialization
    protected virtual void Start()
    {
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Call("start", m_currentLuaTable);
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Call("update", m_currentLuaTable);
        }
    }
    protected virtual void Destroy()
    {
        if (m_currentLuaTable != null)
        {
            m_currentLuaTable.Call("destroy", m_currentLuaTable);
            m_currentLuaTable.Dispose();
            m_currentLuaTable = null;
        }
    }
}
