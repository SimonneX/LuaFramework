﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class ApplicationFacadeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ApplicationFacade), typeof(PureMVC.Patterns.Facade));
		L.RegFunction("StartUp", StartUp);
		L.RegFunction("RegisterLuaCommand", RegisterLuaCommand);
		L.RegFunction("RemoveLuaCommand", RemoveLuaCommand);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("Instance", get_Instance, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartUp(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ApplicationFacade obj = (ApplicationFacade)ToLua.CheckObject<ApplicationFacade>(L, 1);
			obj.StartUp();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterLuaCommand(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ApplicationFacade obj = (ApplicationFacade)ToLua.CheckObject<ApplicationFacade>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.RegisterLuaCommand(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveLuaCommand(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ApplicationFacade obj = (ApplicationFacade)ToLua.CheckObject<ApplicationFacade>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.RemoveLuaCommand(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, ApplicationFacade.Instance);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

