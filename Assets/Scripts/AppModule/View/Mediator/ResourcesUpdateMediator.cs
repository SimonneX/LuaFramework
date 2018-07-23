using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class ResourcesUpdateMediator : Mediator
{
    public ResourcesUpdateMediator(ViewComponent viewComponent) : base("ResourcesUpdateMediator", viewComponent)
    {

    }

    private ResourcesUpdateView updateView
    {
        get
        {
            return m_viewComponent as ResourcesUpdateView;
        }
    }

    public override void OnRegister()
    {

    }
    public override void OnRemove()
    {

    }

    override public IList<string> ListNotificationInterests()
    {
        return new List<string>
        {
            NotificationDefine.RESOURCES_UPDATE_PERCENT
        };
    }

    override public void HandleNotification(INotification notification)
    {
        // Debug.Log("HandleNotification >> " + notification.Name);
        switch (notification.Name)
        {
            case NotificationDefine.RESOURCES_UPDATE_PERCENT:
                UpdateResourcesPercent(notification.Body);
                break;
            default:
                break;
        }
    }

    protected void UpdateResourcesPercent(object data)
    {
        ResourcesUpdateData statusData = data as ResourcesUpdateData;
        updateView.UpdatePercent(statusData.percent);
    }
}
