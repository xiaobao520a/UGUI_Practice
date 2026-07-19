using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerPanel : BasePanel
{
    public Text textServer;
    public Button btnChangeServer;
    public Button btnEnterGame;
    public Button btnReturn;
    public override void Init()
    {
        btnChangeServer.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<ServerPanel>();
        });

        btnEnterGame.onClick.AddListener(() => 
        {
            UIMgr.Instance.HidePanel<ServerPanel>();
            SceneManager.LoadScene("StartScene");
            Destroy(GameObject.Find("BackGroundImg"));
        }
        );

        btnReturn.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<ServerPanel>();
            UIMgr.Instance.ShowPanel<LoginPanel>();
        });
    }
}
