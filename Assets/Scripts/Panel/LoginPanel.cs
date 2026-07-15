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
    private LoginData loginData;
    public override void Init()
    {
        loginData=LoginMgr.Instance.LoginData;
        inputAccount.text = loginData.userAccount == "" ? "ÇëÊäÈëÕËºÅ" : loginData.userAccount;
        inputPassword.text = loginData.rememberPassword ? loginData.password : "ÇëÊäÈëÃÜÂë";
        togRememberPassword.isOn = loginData.rememberPassword;
        togAutoLogin.isOn = loginData.autoLogin;

        btnRegister.onClick.AddListener(() =>
        {

            UIMgr.Instance.HidePanel<LoginPanel>();
        });

        btnSure.onClick.AddListener(() =>
        {
            JsonMgr.Instance.SaveData(loginData,"loginData");
            UIMgr.Instance.HidePanel<LoginPanel>();
        });

        togRememberPassword.onValueChanged.AddListener((isON) =>
        {
            loginData.rememberPassword = isON;
            if (!isON)
            {
                togAutoLogin.isOn = false;
                loginData.autoLogin = false;
            }
        });

        togAutoLogin.onValueChanged.AddListener((isOn) =>
        {
            loginData.autoLogin = isOn;
            if (isOn)
            {
                togRememberPassword.isOn = true;
                loginData.rememberPassword= true;
            }
        });

        inputAccount.onValueChanged.AddListener((value) =>
        {
            loginData.userAccount = value;
        });

        inputPassword.onValueChanged.AddListener((value) =>
        {
            loginData.password = value;
        });
    }

}
