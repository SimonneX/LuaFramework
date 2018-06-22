LoginView = BaseView:extend()

function LoginView:new(gameObject)
    self.gameObject = gameObject
end

function LoginView:awake()
    print("" .. self.gameObject.name)
end

function LoginView:start()
end

function LoginView:update()
end

function LoginView:destroy()
end
