using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIMgr
{
    private static UIMgr instance;
    public static UIMgr Instance
    {
        get
        {
            if (instance == null)
                instance = new UIMgr();
            return instance;
        }
    }

    private Transform canvasTransform;
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    private UIMgr() 
    {
        canvasTransform=GameObject.Find("Canvas").transform;
        GameObject.DontDestroyOnLoad(canvasTransform.gameObject);
    }


   

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T ShowPanel<T>() where T : BasePanel
    {
        string name=typeof(T).Name;
        if (!panelDic.ContainsKey(name))
        {
            GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("Panel/" + name), canvasTransform);
            T Panel = panelObj.GetComponent<BasePanel>() as T;
            Panel.ShowMe();
            panelDic.Add(name, Panel);
            return Panel;
        }
        else
            return panelDic[name] as T;
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hideCallBack"></param>
    public void HidePanel<T>(UnityAction hideCallBack=null)where T : BasePanel
    {
        string name=typeof(T).Name;
        if (!panelDic.ContainsKey(name)) return;

        T panel = panelDic[name] as T;
        panel.HideMe(hideCallBack);
        panelDic.Remove(name);
    }

    /// <summary>
    /// 得到面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetPanel<T>() where T : BasePanel
    {
        string name= typeof(T).Name;
        if (!panelDic.ContainsKey(name)) return null;
        return panelDic[name] as T;
    }
    

}
