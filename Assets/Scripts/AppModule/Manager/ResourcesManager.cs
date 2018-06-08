using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Manager
{
    public static Object GetResources(string relativePath)
    {
        return Resources.Load(relativePath);
    }
    void Start()
    {
    }

    void Update()
    {

    }
}
