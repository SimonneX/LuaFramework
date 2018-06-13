using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShowResourcesUpdateCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);
        SceneManager.LoadScene("ResourcesUpdate");
    }
}