--[[
- commandManager.lua
- @author simonne.xu
- @description 
- @created Thu Jun 21 2018 10:50:48 GMT+0800 (CST)
- @last-modified Thu Jun 21 2018 10:51:45 GMT+0800 (CST)
]]
CommandManager = Object:extend()

CommandManager.GetInstance = function()
    if CommandManager._instance == nil then
        CommandManager._instance = CommandManager()
    end
    return CommandManager._instance
end

function CommandManager.ExecuteFunction(notificationName, notificationBody)
    CommandManager.GetInstance():execute(notificationName, notificationBody)
end

function CommandManager:new()
end

function CommandManager:init()
    self.commandMap = {}
    self:registerCommands()
end

function CommandManager:registerCommands()
    self:registerCommand(NotificationDefine.TEST_COMMAND, TestCommand)
end

function CommandManager:registerCommand(notificationName, commandCls)
    self.commandMap[notificationName] = commandCls
    ApplicationFacade.Instance:RegisterLuaCommand(notificationName)
end

function CommandManager:execute(notificationName, notificationBody)
    local cls = self.commandMap[notificationName]
    if cls == nil then
        return
    end

    local instance = cls()
    instance:execute(notificationName, notificationBody)
end
