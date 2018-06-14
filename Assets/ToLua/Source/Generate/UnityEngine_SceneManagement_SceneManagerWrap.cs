﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_SceneManagement_SceneManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("SceneManager");
		L.RegFunction("GetActiveScene", GetActiveScene);
		L.RegFunction("SetActiveScene", SetActiveScene);
		L.RegFunction("GetSceneByPath", GetSceneByPath);
		L.RegFunction("GetSceneByName", GetSceneByName);
		L.RegFunction("GetSceneByBuildIndex", GetSceneByBuildIndex);
		L.RegFunction("GetSceneAt", GetSceneAt);
		L.RegFunction("LoadScene", LoadScene);
		L.RegFunction("LoadSceneAsync", LoadSceneAsync);
		L.RegFunction("CreateScene", CreateScene);
		L.RegFunction("UnloadSceneAsync", UnloadSceneAsync);
		L.RegFunction("MergeScenes", MergeScenes);
		L.RegFunction("MoveGameObjectToScene", MoveGameObjectToScene);
		L.RegVar("sceneCount", get_sceneCount, null);
		L.RegVar("sceneCountInBuildSettings", get_sceneCountInBuildSettings, null);
		L.RegVar("sceneLoaded", get_sceneLoaded, set_sceneLoaded);
		L.RegVar("sceneUnloaded", get_sceneUnloaded, set_sceneUnloaded);
		L.RegVar("activeSceneChanged", get_activeSceneChanged, set_activeSceneChanged);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetActiveScene(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UnityEngine.SceneManagement.Scene o = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
			ToLua.PushValue(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetActiveScene(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.SceneManagement.Scene arg0 = StackTraits<UnityEngine.SceneManagement.Scene>.Check(L, 1);
			bool o = UnityEngine.SceneManagement.SceneManager.SetActiveScene(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSceneByPath(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.SceneManagement.Scene o = UnityEngine.SceneManagement.SceneManager.GetSceneByPath(arg0);
			ToLua.PushValue(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSceneByName(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.SceneManagement.Scene o = UnityEngine.SceneManagement.SceneManager.GetSceneByName(arg0);
			ToLua.PushValue(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSceneByBuildIndex(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			UnityEngine.SceneManagement.Scene o = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(arg0);
			ToLua.PushValue(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSceneAt(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			UnityEngine.SceneManagement.Scene o = UnityEngine.SceneManagement.SceneManager.GetSceneAt(arg0);
			ToLua.PushValue(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadScene(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes<int>(L, 1))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				UnityEngine.SceneManagement.SceneManager.LoadScene(arg0);
				return 0;
			}
			else if (count == 1 && TypeChecker.CheckTypes<string>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				UnityEngine.SceneManagement.SceneManager.LoadScene(arg0);
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes<int, UnityEngine.SceneManagement.LoadSceneMode>(L, 1))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				UnityEngine.SceneManagement.LoadSceneMode arg1 = (UnityEngine.SceneManagement.LoadSceneMode)ToLua.ToObject(L, 2);
				UnityEngine.SceneManagement.SceneManager.LoadScene(arg0, arg1);
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string, UnityEngine.SceneManagement.LoadSceneMode>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				UnityEngine.SceneManagement.LoadSceneMode arg1 = (UnityEngine.SceneManagement.LoadSceneMode)ToLua.ToObject(L, 2);
				UnityEngine.SceneManagement.SceneManager.LoadScene(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.SceneManagement.SceneManager.LoadScene");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadSceneAsync(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes<int>(L, 1))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				UnityEngine.AsyncOperation o = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes<string>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				UnityEngine.AsyncOperation o = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<int, UnityEngine.SceneManagement.LoadSceneMode>(L, 1))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				UnityEngine.SceneManagement.LoadSceneMode arg1 = (UnityEngine.SceneManagement.LoadSceneMode)ToLua.ToObject(L, 2);
				UnityEngine.AsyncOperation o = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string, UnityEngine.SceneManagement.LoadSceneMode>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				UnityEngine.SceneManagement.LoadSceneMode arg1 = (UnityEngine.SceneManagement.LoadSceneMode)ToLua.ToObject(L, 2);
				UnityEngine.AsyncOperation o = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.SceneManagement.SceneManager.LoadSceneAsync");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateScene(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.SceneManagement.Scene o = UnityEngine.SceneManagement.SceneManager.CreateScene(arg0);
			ToLua.PushValue(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadSceneAsync(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes<UnityEngine.SceneManagement.Scene>(L, 1))
			{
				UnityEngine.SceneManagement.Scene arg0 = StackTraits<UnityEngine.SceneManagement.Scene>.To(L, 1);
				UnityEngine.AsyncOperation o = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes<string>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				UnityEngine.AsyncOperation o = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes<int>(L, 1))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				UnityEngine.AsyncOperation o = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MergeScenes(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.SceneManagement.Scene arg0 = StackTraits<UnityEngine.SceneManagement.Scene>.Check(L, 1);
			UnityEngine.SceneManagement.Scene arg1 = StackTraits<UnityEngine.SceneManagement.Scene>.Check(L, 2);
			UnityEngine.SceneManagement.SceneManager.MergeScenes(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveGameObjectToScene(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			UnityEngine.SceneManagement.Scene arg1 = StackTraits<UnityEngine.SceneManagement.Scene>.Check(L, 2);
			UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneCount(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.SceneManagement.SceneManager.sceneCount);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneCountInBuildSettings(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneLoaded(IntPtr L)
	{
		ToLua.Push(L, new EventObject(typeof(UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.LoadSceneMode>)));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneUnloaded(IntPtr L)
	{
		ToLua.Push(L, new EventObject(typeof(UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene>)));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeSceneChanged(IntPtr L)
	{
		ToLua.Push(L, new EventObject(typeof(UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.Scene>)));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sceneLoaded(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.SceneManagement.SceneManager.sceneLoaded' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.SceneManagement.SceneManager'");
			}

			if (arg0.op == EventOp.Add)
			{
				UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.LoadSceneMode> ev = (UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.LoadSceneMode>)arg0.func;
				UnityEngine.SceneManagement.SceneManager.sceneLoaded += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.LoadSceneMode> ev = (UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.LoadSceneMode>)arg0.func;
				UnityEngine.SceneManagement.SceneManager.sceneLoaded -= ev;
			}

			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sceneUnloaded(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.SceneManagement.SceneManager.sceneUnloaded' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.SceneManagement.SceneManager'");
			}

			if (arg0.op == EventOp.Add)
			{
				UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene> ev = (UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene>)arg0.func;
				UnityEngine.SceneManagement.SceneManager.sceneUnloaded += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene> ev = (UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene>)arg0.func;
				UnityEngine.SceneManagement.SceneManager.sceneUnloaded -= ev;
			}

			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_activeSceneChanged(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.SceneManagement.SceneManager.activeSceneChanged' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.SceneManagement.SceneManager'");
			}

			if (arg0.op == EventOp.Add)
			{
				UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.Scene> ev = (UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.Scene>)arg0.func;
				UnityEngine.SceneManagement.SceneManager.activeSceneChanged += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.Scene> ev = (UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene,UnityEngine.SceneManagement.Scene>)arg0.func;
				UnityEngine.SceneManagement.SceneManager.activeSceneChanged -= ev;
			}

			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

