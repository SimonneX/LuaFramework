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
    public float percent;

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

    public void SetPercent(float per)
    {
        this.percent = per;
        if (per >= 1.0f)
        {
            this.percent = 1.0f;
            this.status = UPDATE_STATUS.FINISH;
        }
    }

    public ResourcesUpdateData(UPDATE_STATUS status, float percent)
    {
        this.status = status;
        this.percent = percent;
    }


}