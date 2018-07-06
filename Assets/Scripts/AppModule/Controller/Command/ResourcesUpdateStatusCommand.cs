using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class ResourcesUpdateStatusCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);


        ResourcesUpdateData data = notification.Body as ResourcesUpdateData;
        if (data.IsFinish())
        {
            SendNotification(NotificationDefine.START_LUA);
        }
    }
}