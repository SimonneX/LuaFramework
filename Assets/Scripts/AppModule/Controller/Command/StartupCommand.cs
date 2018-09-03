using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using DG.Tweening;

public class StartupCommand : SimpleCommand
{
    override public void Execute(INotification notification)
    {
        base.Execute(notification);

        // DOTween
        DOTween.Init();

        // search path
        ResourcesManager.Instance.AddSearchPath(Application.persistentDataPath);
        ResourcesManager.Instance.AddSearchPath(Application.streamingAssetsPath);

        UIUtils.ShowUIViewWithinPrefabs(SplashView.PREFAB_PATH);
    }
}