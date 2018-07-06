using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesUpdateData : Object
{
    public enum UPDATE_STATUS
    {
        NONE,
        DOWNLOADING,
        FINISH,
        ERROR,
    };

    /// <summary>
    /// if percent is 1, status will be changed to Finish
    /// </summary>
    public UPDATE_STATUS status = UPDATE_STATUS.NONE;
    /// <summary>
    /// from 0-1
    /// </summary>
    public float percent
    {
        set
        {
            percent = value;
            if (value >= 1.0f)
            {
                percent = 1.0f;
                status = UPDATE_STATUS.FINISH;
            }
        }
        get
        {
            return percent;
        }
    }

    public void Reset()
    {
        this.status = UPDATE_STATUS.NONE;
        this.percent = 0;
    }

    public bool IsFinish()
    {
        return this.status == UPDATE_STATUS.FINISH;
    }

    public ResourcesUpdateData()
    {
        Reset();
    }

    public ResourcesUpdateData(UPDATE_STATUS status, float percent)
    {
        this.status = status;
        this.percent = percent;
    }


}