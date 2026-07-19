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
        serverData = JsonMgr.Instance.LoadData<List<ServerInfo>>("serverData");
    }

    private LoginData loginData;
    public LoginData LoginData => loginData;

    private RegisterData registerData;
    public RegisterData RegisterData => registerData;

    private List<ServerInfo> serverData;
    public List<ServerInfo> ServerData => serverData;

    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData, "loginData");
    }

    public void SaveRegisterData()
    {
        JsonMgr.Instance.SaveData(registerData,"registerData");
    }

    public bool Register(string userAccount, string password)
    {
        if (registerData.registerData.ContainsKey(userAccount))
        {
            TipPanel tipPanel=UIMgr.Instance.ShowPanel<TipPanel>();
            tipPanel.ChangeText("∏√’À∫≈“—¥Ê‘⁄");
            return false;
        }
        else
        {
            registerData.registerData.Add(userAccount, password);
            SaveRegisterData();
            return true;
        }
    }

    public bool LoginRight(string userAccount, string password)
    {
        if (userAccount.Length > 6 || password.Length > 6||
            !registerData.registerData.ContainsKey(userAccount))
        {
            UIMgr.Instance.ShowPanel<TipPanel>().ChangeText("’À∫≈ªÚ√‹¬Î¥ÌŒÛ");
            return false;
        }
        else
        {
            if (registerData.registerData[userAccount] == password)
                return true;
            return false;
        }
    }

    
}
