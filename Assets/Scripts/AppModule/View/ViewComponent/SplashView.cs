using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;
using DG.Tweening;

public class SplashView : ViewComponent
{
    public Text splashText;
    public const string EVENT_SPLASH_FINISH = "EVENT_SPLASH_FINISH";
    override protected Mediator GetMediator()
    {
        return new SplashMediator(this);
    }

    // Use this for initialization
    void Start()
    {
        splashText.DOText("Lua Framework", 1).onComplete = () => { NotifyEvent(EVENT_SPLASH_FINISH); };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
