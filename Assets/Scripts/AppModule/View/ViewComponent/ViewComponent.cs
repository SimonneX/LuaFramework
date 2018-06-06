using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine.UI;

public class ViewComponent : MonoBehaviour
{

    public delegate void EventDelegate(Object dataObj);
    protected Dictionary<string, EventDelegate> m_eventList = new Dictionary<string, EventDelegate>();

    public void AddEventListener(string eventName, EventDelegate del)
    {
        m_eventList.Add(eventName, del);
    }

    protected void NotifyEvent(string eventName, Object dataObj = null)
    {
        foreach (KeyValuePair<string, EventDelegate> kvp in m_eventList)
        {
            if (kvp.Key.Equals(eventName))
            {
                kvp.Value(dataObj);
            }
        }
    }

    protected Mediator m_mediator = null;

    protected virtual void Awake()
    {
        m_mediator = GetMediator();
        if (m_mediator != null)
        {
            ApplicationFacade.Instance.RegisterMediator(m_mediator);
        }
    }

    protected virtual void OnDestroy()
    {
        if (m_mediator != null)
        {
            ApplicationFacade.Instance.RemoveMediator(m_mediator.MediatorName);
        }
    }

    protected virtual Mediator GetMediator()
    {
        return null;
    }
}
