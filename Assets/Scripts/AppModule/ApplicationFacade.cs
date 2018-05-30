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
    }

    override protected void InitializeView()
    {
        base.InitializeView();
        RegisterMediator(new LoginMeditor());
    }

    public void StartUp()
    {
        SendNotification(NotificationDefine.STARTUP);
    }
}