using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoginMgr
{
    private static LoginMgr instance;
    public static LoginMgr Instance
    {
        get
        {
            if(instance == null) instance = new LoginMgr();
            return instance;
        }
    }
    private LoginMgr() 
    {
        loginData=JsonMgr.Instance.LoadData<LoginData>("loginData");
        registerData = JsonMgr.Instance.LoadData<RegisterData>("registerData");
    }

    private LoginData loginData;
    public LoginData LoginData => loginData;

    private RegisterData registerData;
    public RegisterData RegisterData => registerData;

    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData, "loginData");
    }

    public void SaveRegisterData()
    {
        JsonMgr.Instance.SaveData(registerData,"registerData");
    }

    
}
