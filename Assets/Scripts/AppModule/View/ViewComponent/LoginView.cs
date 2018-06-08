using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;

public class LoginView : ViewComponent
{
    public const string LOGIN_CLICK = "LOGIN_CLICK";
    public Button loginButton;
    public InputField userNameInput;
    public InputField passwordInput;

    override protected Mediator GetMediator()
    {
        return new LoginMeditor(this);
    }

    // Use this for initialization
    void Start()
    {
        loginButton.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected void OnClickButton()
    {
        LoginData obj = new LoginData(userNameInput.text, passwordInput.text);
        NotifyEvent(LOGIN_CLICK, obj);
    }
}
