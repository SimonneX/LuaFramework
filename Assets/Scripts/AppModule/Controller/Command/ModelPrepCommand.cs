using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class ModelPrepCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        Debug.Log("ModelPrepCommand >> Execute >> " + notification.Name);
    }
}