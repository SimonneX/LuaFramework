using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;

public class SplashView : ViewComponent
{
    public const string EVENT_SPLASH_FINISH = "EVENT_SPLASH_FINISH";
    override protected Mediator GetMediator()
    {
        return new SplashMediator(this);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
