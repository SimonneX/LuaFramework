using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

[System.Serializable]
public class LuaVariable
{
    public enum VALUE_TYPE
    {
        Int,
        Float,
        String,
        GameObject,
    }
    public string key;
    public VALUE_TYPE type;
    public GameObject Objectvalue;
    public int intValue;
    public string stringValue;
    public float floatValue;
}
public class LuaBehaviour : ViewComponent
{
    /// <summary>
    /// lua的类名
    /// 不写默认为GameObject的名字
    /// </summary>
    public string luaClassName = null;
    /// <summary>
    /// 需要注入到lua中的变量
    /// </summary>
    public LuaVariable[] luaVariableList;

    protected LuaTable m_currentLuaTable = null;

    protected virtual void Awake()
    {
        if (luaClassName == null | luaClassName.Length == 0)
        {
            luaClassName = gameObject.name;
        }

        m_currentLuaTable = LuaManager.Instance.PCallTableLuaFunction(luaClassName + ".create", gameObject);

        InitLuaVariable();
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
        if (m_currentLuaTable == null)
            return;

        m_currentLuaTable.Call(luaFunctionName, m_currentLuaTable);
    }

    protected virtual void InitLuaVariable()
    {
        if (m_currentLuaTable == null)
            return;

        for (int i = 0; i < luaVariableList.Length; ++i)
        {
            LuaVariable.VALUE_TYPE type = luaVariableList[i].type;
            switch (type)
            {
                case LuaVariable.VALUE_TYPE.Int:
                    m_currentLuaTable.RawSet(luaVariableList[i].key, luaVariableList[i].intValue);
                    break;
                case LuaVariable.VALUE_TYPE.String:
                    m_currentLuaTable.RawSet(luaVariableList[i].key, luaVariableList[i].stringValue);
                    break;
                case LuaVariable.VALUE_TYPE.Float:
                    m_currentLuaTable.RawSet(luaVariableList[i].key, luaVariableList[i].floatValue);
                    break;
                case LuaVariable.VALUE_TYPE.GameObject:
                    m_currentLuaTable.RawSet(luaVariableList[i].key, luaVariableList[i].Objectvalue);
                    break;
                default:
                    break;
            }
        }
    }
}
