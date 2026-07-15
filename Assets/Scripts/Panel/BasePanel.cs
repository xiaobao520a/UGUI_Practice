using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private float alphaSpeed = 6f;
    private bool isShow = false;

    private UnityAction hideCallBack = null;


    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = this.AddComponent<CanvasGroup>();
    }
    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        if (isShow && canvasGroup.alpha < 1)
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;

        else if (!isShow && canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
            if(canvasGroup.alpha <= 0)
            {
                if(hideCallBack==null)
                    Destroy(gameObject);
                else
                    hideCallBack?.Invoke();
            }
        }
    }

    public abstract void Init();
    public virtual void ShowMe()
    {
        if (isShow) return;
        isShow = true;
    }

    public virtual void HideMe(UnityAction hideCallBack)
    {
        if(!isShow) return;
        isShow = false;
        this.hideCallBack = hideCallBack;
    }
}
