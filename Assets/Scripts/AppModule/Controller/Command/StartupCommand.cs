using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using DG.Tweening;

public class StartupCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        // DOTween
        DOTween.Init();

        // Manager
        GameObject managerObj = GameObject.Find("Manager");
        if (managerObj)
        {
            managerObj.AddComponent<LuaManager>();
            managerObj.AddComponent<ResourcesManager>();
        }
        else
        {
            Debug.LogWarning("StartupCommand >> Execute >> GameObject: Manager not found");
        }

    }
}