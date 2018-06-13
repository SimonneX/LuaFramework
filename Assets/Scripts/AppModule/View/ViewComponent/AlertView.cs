using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AlertView : MonoBehaviour
{
    public Text alertText;
    public Image bgImage;

    public string Message
    {
        get
        {
            return alertText.text;
        }
        set
        {
            alertText.text = value;
        }
    }

    private bool isShow = false;

    public static void Show(string message)
    {
        ResourcesManager resMgr = ResourcesManager.Instance as ResourcesManager;
        GameObject alertGo = Instantiate(resMgr.GetResources("Prefabs/UIAlert")) as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        alertGo.transform.SetParent(canvas.transform);
        alertGo.transform.localPosition = Vector3.zero;

        AlertView view = alertGo.GetComponent<AlertView>();
        view.Message = message;
    }

    // Use this for initialization
    void Start()
    {
        ShowAnimation();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShowAnimation()
    {
        float interval = 1.0f;
        bgImage.DOFade(0, interval);
        alertText.DOFade(0, interval);
        transform.DOLocalMoveY(300, interval + 0.1f).onComplete = () => { Destroy(gameObject); };
    }
}
