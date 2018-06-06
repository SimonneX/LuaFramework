using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;

public class LoginDataObject : Object
{
    public LoginDataObject(string username)
    {
        strUserName = username;
    }
    public string strUserName;
}
public class LoginView : ViewComponent
{
    public const string LOGIN_CLICK = "LOGIN_CLICK";
    public Button loginButton;
    public InputField userNameInput;

    override protected Mediator GetMediator()
    {
        return new LoginMeditor(this);
    }

    public void OnClickButton()
    {
        LoginDataObject obj = new LoginDataObject(userNameInput.text);
        NotifyEvent(LOGIN_CLICK, obj);
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
}
