using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public Button btnRegister;
    public Button btnSure;
    public Toggle togRememberPassword;
    public Toggle togAutoLogin;
    public InputField inputAccount;
    public InputField inputPassword;
    public override void Init()
    {
        //一开始要根据加载出来的loginData去显示面板内容
        togRememberPassword.isOn = LoginMgr.Instance.LoginData.rememberPassword;
        togAutoLogin.isOn = LoginMgr.Instance.LoginData.autoLogin;

        inputAccount.text = LoginMgr.Instance.LoginData.userAccount == "" ?
        "请输入账号" : LoginMgr.Instance.LoginData.userAccount;

        if (togRememberPassword.isOn && LoginMgr.Instance.LoginData.password != "")
            inputPassword.text = LoginMgr.Instance.LoginData.password;
        else
            inputPassword.text = "请输入密码";

        btnRegister.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<LoginPanel>();
        });

        btnSure.onClick.AddListener(() =>
        {
            //暂时先这样 实际上肯定是得先检测账号密码是否正确再保存
            SaveLoginData();
            UIMgr.Instance.HidePanel<LoginPanel>();
        });

        togRememberPassword.onValueChanged.AddListener((isON) =>
        {
            if (!isON)
                togAutoLogin.isOn = false;
        });

        togAutoLogin.onValueChanged.AddListener((isOn) =>
        {
            if (isOn)
                togRememberPassword.isOn = true;
        });

        inputAccount.onValueChanged.AddListener((value) =>
        {

        });

        inputPassword.onValueChanged.AddListener((value) =>
        {

        });
    }

    private void SaveLoginData()
    {
        LoginMgr.Instance.LoginData.rememberPassword = togRememberPassword.isOn;
        LoginMgr.Instance.LoginData.autoLogin=togAutoLogin.isOn;
        LoginMgr.Instance.LoginData.userAccount = inputAccount.text;
        LoginMgr.Instance.LoginData.password = inputPassword.text;
        JsonMgr.Instance.SaveData(LoginMgr.Instance.LoginData, "loginData");
    }
}
