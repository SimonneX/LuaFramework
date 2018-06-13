using PureMVC.Patterns;
using UnityEngine;

public class ApplicationFacade : Facade
{

    private static ApplicationFacade s_instance;

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

    override protected void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotificationDefine.STARTUP, typeof(StartupCommand));
        RegisterCommand(NotificationDefine.SHOW_LOGIN_SCENE, typeof(ShowLoginSceneCommand));
        RegisterCommand(NotificationDefine.LOGIN, typeof(LoginCommand));
        RegisterCommand(NotificationDefine.SHOW_ALERT_VIEW, typeof(ShowAlertCommand));
    }

    public void StartUp()
    {
        SendNotification(NotificationDefine.STARTUP);
    }
}