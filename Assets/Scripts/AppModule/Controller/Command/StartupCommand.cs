using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class StartupCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        Debug.Log("StartupCommand >> Execute >> " + notification.Name);

        GameObject managerObj = GameObject.Find("Manager");
        if (managerObj)
        {
            managerObj.AddComponent<GameManager>();

            SendNotification(NotificationDefine.LOGIN);
        }
        else
        {
            Debug.LogWarning("StartupCommand >> Execute >> GameObject: Manager not found");
        }
    }
}