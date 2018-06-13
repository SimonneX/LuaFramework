using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;

public class ResourcesUpdateView : ViewComponent
{
    public Text valueText;
    public void UpdatePercent(float percent)
    {
        valueText.text = Mathf.Max(0, Mathf.Min(100, (int)(percent * 100))) + "%";
        // Debug.Log("ResourcesUpdateView >> UpdatePercent >> " + percent);
    }
    override protected Mediator GetMediator()
    {
        return new ResourcesUpdateMediator(this);
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
