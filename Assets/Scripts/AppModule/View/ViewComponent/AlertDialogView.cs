using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AlertDialogView : MonoBehaviour
{
    protected const string PREFAB_RES_PATH = "UIAlertDialog";

    public Button okButton;
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

    public static void Show(string message)
    {
        ResourcesManager resMgr = ResourcesManager.Instance;
        GameObject alertGo = UIUtils.ShowUIViewWithinStatic(PREFAB_RES_PATH);
        if (alertGo == null)
        {
            return;
        }
        AlertDialogView view = alertGo.GetComponent<AlertDialogView>();
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

    public void OnClickOkButton()
    {
        Destroy(gameObject);
    }

    void ShowAnimation()
    {
        gameObject.transform.localScale = 0.4f * Vector3.one;
        gameObject.transform.DOScale(1.0f, 0.3f);
    }
}
