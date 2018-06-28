LoginView = BaseView:extend()

function LoginView:new()
end

function LoginView:awake()
    print("" .. self.gameObject.name)
    self.loginButton = self.loginButtonObject:GetComponent("UnityEngine.UI.Button")
    self.userNameInputField = self.userNameObject:GetComponent("UnityEngine.UI.InputField")
    self.passwordInputField = self.passwordObject:GetComponent("UnityEngine.UI.InputField")
end

function LoginView:start()
    self.manager:AddClick(self.loginButton.gameObject, self.onButtonClick, self)
end

function LoginView:update()
end

function LoginView:destroy()
end

function LoginView:onButtonClick(go)
    print("LoginInfo >> userName:" .. self.userNameInputField.text .. ",password:" .. self.passwordInputField.text)
end
