using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class UserProxy : Proxy
{
    public static string NAME = "UserProxy";
    public UserProxy() : base(UserProxy.NAME)
    {

    }
    public UserProxy(Object data) : base(UserProxy.NAME, data)
    {

    }

    public void Login(Object dataObj)
    {
        LoginData data = dataObj as LoginData;
        if (data.userName.Length <= Constant.ZERO)
        {
            SendNotification(NotificationDefine.LOGIN_FAIL);
            return;
        }

        if (data.password.Length <= Constant.ZERO)
        {
            SendNotification(NotificationDefine.LOGIN_FAIL);
            return;
        }
        SendNotification(NotificationDefine.LOGIN_SUCCESS);
    }
}
