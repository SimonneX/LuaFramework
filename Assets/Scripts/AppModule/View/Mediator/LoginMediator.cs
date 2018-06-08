using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class LoginMeditor : Mediator
{
    public LoginMeditor(ViewComponent viewComponent) : base("LoginMeditor", viewComponent)
    {

    }

    private LoginView loginView
    {
        get
        {
            return m_viewComponent as LoginView;
        }
    }

    public override void OnRegister()
    {
        loginView.AddEventListener(LoginView.LOGIN_CLICK, OnLoginEvent);
    }
    public override void OnRemove()
    {

    }

    override public IList<string> ListNotificationInterests()
    {
        return new List<string>
        {
            NotificationDefine.LOGIN_SUCCESS,
            NotificationDefine.LOGIN_FAIL,
        };
    }

    override public void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case NotificationDefine.LOGIN_SUCCESS:
                ShowLoginSuccess();
                break;
            case NotificationDefine.LOGIN_FAIL:
                ShowLoginFail();
                break;
            default:
                break;
        }
    }


    protected void OnLoginEvent(Object obj)
    {
        LoginData data = obj as LoginData;
        SendNotification(NotificationDefine.LOGIN, obj);
    }

    protected void ShowLoginSuccess()
    {
        SendNotification(NotificationDefine.SHOW_ALERT_VIEW, "Login Success");
    }

    protected void ShowLoginFail()
    {
        SendNotification(NotificationDefine.SHOW_ALERT_VIEW, "Login Fail");
    }
}
