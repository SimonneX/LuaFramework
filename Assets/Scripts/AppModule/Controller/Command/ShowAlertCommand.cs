using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using DG.Tweening;

public class AlertViewData
{
    public enum ALERT_TYPE
    {
        DIALOG = 0,
        POPUP,
    }

    public ALERT_TYPE type;
    public string title = "";
    public string content = "";

    public AlertViewData(string content, string title = "", ALERT_TYPE alertType = ALERT_TYPE.DIALOG)
    {
        this.content = content;
        this.title = title;
        this.type = alertType;
    }
}
public class ShowAlertCommand : SimpleCommand
{

    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        AlertViewData data = notification.Body as AlertViewData;

        switch (data.type)
        {
            case AlertViewData.ALERT_TYPE.POPUP:
                AlertView.Show(data.content);
                break;
            default:
                AlertDialogView.Show(data.content);
                break;
        }

    }
}
