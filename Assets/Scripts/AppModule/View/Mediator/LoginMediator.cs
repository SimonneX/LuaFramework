using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class LoginMeditor : Mediator
{
    public LoginMeditor(ViewComponent viewComponent) : base("LoginMeditor", viewComponent)
    {
        loginView.AddEventListener(LoginView.LOGIN_CLICK, OnLoginEvent);
    }

    private LoginView loginView
    {
        get
        {
            return m_viewComponent as LoginView;
        }
    }


    override public IList<string> ListNotificationInterests()
    {
        return new List<string>
        {
            NotificationDefine.LOGIN,
        };
    }

    override public void HandleNotification(INotification notification)
    {
        // Debug.Log("LoginMeditor >> HandleNotification >> " + notification.Name);
        switch (notification.Name)
        {
            case NotificationDefine.LOGIN:
                InitLoginView();
                break;
            default:
                break;
        }
    }


    protected void OnLoginEvent(Object obj)
    {
        LoginDataObject data = obj as LoginDataObject;
        Debug.Log("Login User:" + data.strUserName);
    }

    protected void InitLoginView()
    {

    }
}
