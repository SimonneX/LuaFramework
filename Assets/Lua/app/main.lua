--[[
- main.lua
- @author simonne.xu
- @description 
- @created Fri Jun 15 2018 16:08:55 GMT+0800 (CST)
- @last-modified Thu Jun 21 2018 10:48:25 GMT+0800 (CST)
]]
local function requireFiles()
	require("app/constant/constant")
	require("app/constant/notificationDefine")

	Object = require("app/common/object")

	require("app/controller/command/define")
end

function main()
	print("===>> Main Start <<===")
	requireFiles()
	LogDebugInfo()

	CommandManager.GetInstance():init()

	local sceneMgr = UnityEngine.SceneManagement.SceneManager
	sceneMgr.LoadScene("Login")
end

-- 调试信息
function LogDebugInfo()
	local application = UnityEngine.Application
	local strLogInfo = "\n====== Debug Info ======\n"
	strLogInfo = strLogInfo .. "Platform: " .. tostring(UnityEngine.Application.platform) .. "\n"
	strLogInfo = strLogInfo .. "Language: " .. tostring(UnityEngine.Application.systemLanguage) .. "\n"
	strLogInfo = strLogInfo .. "Version: " .. tostring(UnityEngine.Application.version) .. "\n"
	strLogInfo = strLogInfo .. "DEBUG: " .. DEBUG .. "\n"
	strLogInfo = strLogInfo .. "==================="
	print(strLogInfo)
end

-- 场景切换通知
function OnLevelWasLoaded(level)
	collectgarbage("collect")
	Time.timeSinceLevelLoad = 0
end

function OnApplicationQuit()
end

main()
