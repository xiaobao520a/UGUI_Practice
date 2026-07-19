using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginData
{
    public string userAccount;
    public string password;
    public bool rememberPassword;
    public bool autoLogin;

    public int ServerID=-1; //-1代表还没选服 0-4 依次代表火爆 繁忙 优秀 维护 没有状态
}
