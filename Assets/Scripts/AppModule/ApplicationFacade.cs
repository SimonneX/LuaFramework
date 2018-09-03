using PureMVC.Interfaces;
using PureMVC.Patterns;

using UnityEngine;
using System.Collections.Generic;
using LuaInterface;

public class ApplicationFacade : Facade
{
    private static ApplicationFacade s_instance;

    public void StartUp()
    {
        SendNotification(NotificationDefine.STARTUP);
    }

    public static ApplicationFacade Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new ApplicationFacade();
            }
            return s_instance;
        }
    }

    protected ApplicationFacade() : base()
    {

    }

    override protected void InitializeFacade()
    {
        base.InitializeFacade();
    }

    override protected void InitializeController()
    {
        base.InitializeController();

        // 游戏启动
        RegisterCommand(NotificationDefine.STARTUP, typeof(StartupCommand));
        // 热更启动
        RegisterCommand(NotificationDefine.START_RESOURCES_UPDATE, typeof(StartResourcesUpdateCommand));
        // 热更完成
        RegisterCommand(NotificationDefine.CHECK_RESOURCES_STATUS_UPDATE, typeof(CheckResourcesStatusUpdateCommand));

        RegisterCommand(NotificationDefine.SHOW_ALERT_VIEW, typeof(ShowAlertCommand));
    }

    public void RegisterLuaCommand(string notificationName)
    {
        RegisterCommand(notificationName, typeof(LuaBridgeCommand));
    }

    public void RemoveLuaCommand(string notificationName)
    {
        RemoveCommand(notificationName);
    }
}