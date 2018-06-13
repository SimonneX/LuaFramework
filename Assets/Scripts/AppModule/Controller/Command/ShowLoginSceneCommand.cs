using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowLoginSceneCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        SceneManager.LoadScene("Login");
    }
}