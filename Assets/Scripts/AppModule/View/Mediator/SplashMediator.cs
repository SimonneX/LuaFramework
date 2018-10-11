using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class SplashMediator : Mediator
{
    public SplashMediator(ViewComponent viewComponent) : base("SplashMediator", viewComponent)
    {

    }

    private SplashView splashView
    {
        get
        {
            return m_viewComponent as SplashView;
        }
    }

    public override void OnRegister()
    {
        splashView.AddEventListener(SplashView.EVENT_SPLASH_FINISH, OnSplashFinishEvent);
    }
    public override void OnRemove()
    {

    }

    override public IList<string> ListNotificationInterests()
    {
        return new List<string>
        {

        };
    }

    override public void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            default:
                break;
        }
    }


    protected void OnSplashFinishEvent(Object obj)
    {
        SendNotification(NotificationDefine.START_RESOURCES_UPDATE);
    }
}
