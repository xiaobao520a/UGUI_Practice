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
        inputAccount.onValueChanged.AddListener((str) =>
        {

        });

        inputPassword.onValueChanged.AddListener((str) =>
        {

        });

        btnCancel.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<RegisterPanel>();
            UIMgr.Instance.ShowPanel<LoginPanel>();
        });

        btnRegister.onClick.AddListener(() =>
        {


        });
    }
}
