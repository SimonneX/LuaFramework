LoginView = BaseView:extend()

function LoginView:new(gameObject)
    self.gameObject = gameObject

    self.varObject = nil
    self.varInt = nil
    self.varFloat = nil
    self.varString = nil
end

function LoginView:awake()
    print("" .. self.gameObject.name)
    print(tostring(self.varObject.name))
    print(tostring(self.varInt))
    print(tostring(self.varFloat))
    print(tostring(self.varString))
end

function LoginView:start()
end

function LoginView:update()
end

function LoginView:destroy()
end
