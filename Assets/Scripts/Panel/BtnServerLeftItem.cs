using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnServerLeftItem : MonoBehaviour
{
    public Button btnServerLeftItem;
    public Text text;

    private int startIndex;
    private int endIndex;

    private void Start()
    {
        btnServerLeftItem.onClick.AddListener(() =>
        {

        });
    }

    public void InitText(int startIndex,int endIndex)
    {
        this.startIndex = startIndex;
        this.endIndex=endIndex;
        text.text = startIndex + "-" + endIndex + "Çø";
    }
}
