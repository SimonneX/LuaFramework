using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DebugView : MonoBehaviour
{
    public GameObject debugPanel;
    public Toggle showToggle;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        RefreshDebugViewState();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnToggleDebugView()
    {
        RefreshDebugViewState();
    }

    public void RefreshDebugViewState()
    {
        debugPanel.active = showToggle.isOn;
    }

    public void OnClickTest()
    {
        Debug.Log("test");
    }
}
