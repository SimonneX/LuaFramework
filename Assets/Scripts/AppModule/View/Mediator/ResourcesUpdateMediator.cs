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
            NotificationDefine.CHECK_RESOURCES_STATUS_UPDATE
        };
    }

    override public void HandleNotification(INotification notification)
    {

        switch (notification.Name)
        {
            case NotificationDefine.CHECK_RESOURCES_STATUS_UPDATE:
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
