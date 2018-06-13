using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Manager
{
    private static ResourcesManager s_instance;
    public static ResourcesManager Instance
    {
        get
        {
            return s_instance;
        }
    }
    protected ResourcesUpdateData updateStatusData = new ResourcesUpdateData();
    protected bool m_bCheckRes = false;
    public void CheckResources()
    {
        m_bCheckRes = true;

    }
    public Object GetResources(string relativePath)
    {
        return Resources.Load(relativePath);
    }

    protected override void Awake()
    {
        base.Awake();
        s_instance = this;
    }

    void Start()
    {
    }

    void Update()
    {
        if (m_bCheckRes)
        {
            updateStatusData.percent += Time.deltaTime;
            SendNotification(NotificationDefine.RESOURCES_UPDATE_PERCENT, updateStatusData);
            if (updateStatusData.percent >= 1.0f)
            {
                SendNotification(NotificationDefine.RESOURCES_UPDATE_PERCENT, updateStatusData);
                SendNotification(NotificationDefine.RESOURCES_UPDATE_FINISH);
                m_bCheckRes = false;
            }
        }
    }
}
