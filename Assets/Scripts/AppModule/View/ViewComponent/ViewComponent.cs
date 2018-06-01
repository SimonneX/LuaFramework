using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine.UI;

public class ViewComponent : MonoBehaviour
{

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
