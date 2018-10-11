/*
 * @Author: simonne.xu 
 * @Date: 2018-08-02 15:26:07 
 * @Last Modified by: simonne.xu
 * @Last Modified time: 2018-08-07 18:07:33
 * @Description: base class of manager 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager<T> : MonoBehaviour
{

    protected static T s_instance;

    public static T Instance
    {
        get
        {
            return s_instance;
        }
    }

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
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected virtual void OnDestroy()
    {

    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void OnDisable()
    {

    }
}
