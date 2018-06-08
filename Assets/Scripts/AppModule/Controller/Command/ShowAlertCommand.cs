using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using DG.Tweening;

public class ShowAlertCommand : SimpleCommand
{

    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        AlertView.Show(notification.Body as string);
    }
}