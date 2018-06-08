using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginData : Object
{
    public LoginData(string name, string password)
    {
        this.userName = name;
        this.password = password;
    }
    public string userName;
    public string password;
}