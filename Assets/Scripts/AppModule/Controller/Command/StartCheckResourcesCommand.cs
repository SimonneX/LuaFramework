using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class StartCheckResourcesCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        ResourcesManager.Instance.CheckResources();
    }
}