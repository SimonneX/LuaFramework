using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class StartupCommand : MacroCommand
{

    override protected void InitializeMacroCommand()
    {
        AddSubCommand(typeof(ModelPrepCommand));
    }
    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        Debug.Log("StartupCommand >> Execute >> " + notification.Name);
        GameObject managerObj = GameObject.Find("Manager");
        if (managerObj)
        {
            managerObj.AddComponent<LuaManager>();
            SendNotification(NotificationDefine.LOGIN);
        }
        else
        {
            Debug.LogWarning("StartupCommand >> Execute >> GameObject: Manager not found");
        }
    }
}