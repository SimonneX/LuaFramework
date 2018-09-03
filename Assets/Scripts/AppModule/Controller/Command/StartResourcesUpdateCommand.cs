using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class StartResourcesUpdateCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        SceneManager.LoadScene("ResourcesUpdate");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "ResourcesUpdate")
        {
            UIUtils.ShowUIViewWithinPrefabs(ResourcesUpdateView.PREFAB_PATH);
            ResourcesManager.Instance.CheckResources();

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}