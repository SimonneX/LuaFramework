using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    protected virtual void SendNotification(string notificationName, object body = null)
    {
        if (body == null)
        {
            ApplicationFacade.Instance.SendNotification(notificationName);
        }
        else
        {
            ApplicationFacade.Instance.SendNotification(notificationName, body);
        }

    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {

    }
}
