TestCommand = Object:extend()

function TestCommand:new()
end

function TestCommand:execute(notificationName, notificationBody)
    print("TestCommand >> " .. notificationName .. " >> " .. notificationBody)
end
