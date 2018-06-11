--[[
- main.lua
- @author simonne
- @created Thu Apr 26 2018 17:53:50 GMT+0800 (中国标准时间)
]]
local function requireFiles()
	require("app/constant/constant")
end

function main()
	requireFiles()
	print("===>> Main Start <<===")
	print("DEBUG: " .. DEBUG)
end

--场景切换通知
function OnLevelWasLoaded(level)
	collectgarbage("collect")
	Time.timeSinceLevelLoad = 0
end

function OnApplicationQuit()
end

main()
