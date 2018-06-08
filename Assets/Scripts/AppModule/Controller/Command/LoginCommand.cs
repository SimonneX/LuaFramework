using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class LoginCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        UserProxy proxy = ApplicationFacade.Instance.RetrieveProxy(UserProxy.NAME) as UserProxy;
        proxy.Login(notification.Body as Object);

    }
}