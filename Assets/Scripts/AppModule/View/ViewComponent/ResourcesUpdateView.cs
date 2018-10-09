using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;
using DG.Tweening;

public class ResourcesUpdateView : ViewComponent
{
    public const string PREFAB_PATH = "ui/resourcesUpdate/ResourcesUpdateView";
    public Text valueText;
    public Text tipsText;
    public Text speedText;

    public void UpdateView(ResourcesUpdateData data)
    {
        valueText.text = Mathf.Max(0, Mathf.Min(100, (int)(data.percent * 100))) + "%";
        if (data.speed > 1024)
        {
            speedText.text = string.Format("{0:f}MB/s", data.speed / 1024);
        }
        else
        {
            speedText.text = string.Format("{0:f}kb/s", data.speed);
        }
    }

    override protected Mediator GetMediator()
    {
        return new ResourcesUpdateMediator(this);
    }
    // Use this for initialization
    void Start()
    {
        tipsText.DOText("Downloading(4MB)...", 1.0f).SetLoops(-1).Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
