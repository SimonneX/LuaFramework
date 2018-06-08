using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // private static Manager s_instance;
    // public static Manager Instance
    // {
    //     get
    //     {
    //         return s_instance;
    //     }
    // }
    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // s_instance = this;
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
