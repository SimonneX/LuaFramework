using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesUpdateData : Object
{
    public enum UPDATE_STATUS
    {
        NONE,
        DOWNLOADING,

    };

    public UPDATE_STATUS status = UPDATE_STATUS.NONE;
    public float percent = 0;

    public ResourcesUpdateData()
    {
        this.status = UPDATE_STATUS.NONE;
        this.percent = 0;
    }
    public ResourcesUpdateData(UPDATE_STATUS status, float percent)
    {
        this.status = status;
        this.percent = percent;
    }


}