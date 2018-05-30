using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class LoginMeditor : Mediator
{

    override public IList<string> ListNotificationInterests()
    {
        List<string> notifications = new List<string>();

        notifications.Add(NotificationDefine.LOGIN);

        return notifications;
    }

    override public void HandleNotification(INotification notification)
    {
        Debug.Log("LoginMeditor >> HandleNotification >> " + notification.Name);
    }
}
