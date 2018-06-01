using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;

public class LoginView : ViewComponent
{
    public Text sampleText;

    public void ShowLoginView()
    {
        if (sampleText == null)
            return;
        sampleText.text = "LoginView";
    }

    override protected Mediator GetMediator()
    {
        return new LoginMeditor(this);
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
