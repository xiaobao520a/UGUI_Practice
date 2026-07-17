using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    public InputField inputAccount;
    public InputField inputPassword;

    public Button btnCancel;
    public Button btnRegister;
    public override void Init()
    {
        
        btnCancel.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<RegisterPanel>();
            UIMgr.Instance.ShowPanel<LoginPanel>();
        });

        btnRegister.onClick.AddListener(() =>
        {
            if(inputAccount.text.Length>6||inputPassword.text.Length>6)
            {
                UIMgr.Instance.ShowPanel<TipPanel>().ChangeText("账号或密码不能超过六位");
                inputAccount.text = "";
                inputPassword.text = "";
            }
            else
            {
                if(LoginMgr.Instance.Register(inputAccount.text,inputPassword.text))
                {
                    UIMgr.Instance.HidePanel<RegisterPanel>();
                    LoginPanel loginPanel = UIMgr.Instance.ShowPanel<LoginPanel>();
                    loginPanel.SetInfo(inputAccount.text, inputPassword.text);
                    UIMgr.Instance.ShowPanel<TipPanel>().ChangeText("注册成功");

                }
                else
                {
                    UIMgr.Instance.ShowPanel<TipPanel>().ChangeText("注册失败,账号已存在");
                    inputAccount.text = "";
                    inputPassword.text = "";
                }
            }

        });
    }
}
