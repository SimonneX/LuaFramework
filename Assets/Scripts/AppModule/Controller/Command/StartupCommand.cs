using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using DG.Tweening;

public class StartupCommand : MacroCommand
{

    override protected void InitializeMacroCommand()
    {
        AddSubCommand(typeof(ModelPrepCommand));
    }
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
        }
        else
        {
            Debug.LogWarning("StartupCommand >> Execute >> GameObject: Manager not found");
        }

    }
}