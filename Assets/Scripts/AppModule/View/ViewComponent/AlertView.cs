using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AlertView : MonoBehaviour
{
    protected const string PREFAB_RES_PATH = "AlertView";

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

    public delegate void SimpleClickDelegate();

    protected SimpleClickDelegate m_clickDel;

    public static void Show(string message, SimpleClickDelegate okDel = null)
    {
        GameObject alertGo = UIUtils.ShowUIViewWithinStatic(PREFAB_RES_PATH);
        if (alertGo == null)
        {
            return;
        }
        AlertView view = alertGo.GetComponent<AlertView>();
        view.SetClickDelegate(okDel);
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

    public void SetClickDelegate(SimpleClickDelegate del)
    {
        m_clickDel = del;
    }

    public void OnClickOkButton()
    {
        if (m_clickDel != null)
        {
            m_clickDel();
        }
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        m_clickDel = null;
    }

    void ShowAnimation()
    {
        gameObject.transform.localScale = 0.4f * Vector3.one;
        gameObject.transform.DOScale(1.0f, 0.3f);
    }
}
