using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class StartLuaCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        LuaManager.Instance.Init();
        LuaManager.Instance.StartMain();
    }
}