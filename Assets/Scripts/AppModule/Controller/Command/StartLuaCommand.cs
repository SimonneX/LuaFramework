using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class StartLuaCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        ResourcesUpdateData data = notification.Body as ResourcesUpdateData;
        if (!data.IsFinish())
        {
            return;
        }
        LuaManager.Instance.Init();
        LuaManager.Instance.StartMain();
    }
}