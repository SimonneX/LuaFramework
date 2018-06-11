using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    void Start()
    {
        ApplicationFacade.Instance.StartUp();
        Debug.Log("DataPath:" + Application.dataPath);
    }

    void Update()
    {

    }
}
