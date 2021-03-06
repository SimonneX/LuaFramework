using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using LuaInterface;

public class LuaBridgeCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);
        LuaManager.Instance.PCallVoidLuaFunction("CommandManager.ExecuteFunction", notification.Name, notification.Body);
    }
}