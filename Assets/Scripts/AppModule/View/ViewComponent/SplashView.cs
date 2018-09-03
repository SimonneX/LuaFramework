using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;
using DG.Tweening;

public class SplashView : ViewComponent
{
    public const string PREFAB_PATH = "ui/SplashView";
    public const string EVENT_SPLASH_FINISH = "EVENT_SPLASH_FINISH";

    public Text splashText;
    override protected Mediator GetMediator()
    {
        return new SplashMediator(this);
    }

    // Use this for initialization
    void Start()
    {
        splashText.DOFade(1.0f, 0.5f).onComplete = () =>
        {
            splashText.DOFade(0.0f, 0.1f).onComplete = () =>
            {
                NotifyEvent(EVENT_SPLASH_FINISH);
            };
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
