using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel :BasePanel
{
    public Button btnSure;

    public Text textInfo;
    public override void Init()
    {
        btnSure.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<TipPanel>();
        });
    }

    public void ChangeText(string info)
    {
        textInfo.text = info;
    }
}
