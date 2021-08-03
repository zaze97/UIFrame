using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 存储所有UI的信息，并可创建或者销毁UI
/// </summary>
public class UIManager
{
    /// <summary>
    /// 存储所有UI信息的字典，每个UI信息都会对应一个GameObject
    /// </summary>
    private Dictionary<UIType, GameObject> dicUI;


    /// <summary>
    /// 构造器初始化
    /// </summary>
    public UIManager()
    {
        dicUI = new Dictionary<UIType, GameObject>();
    }
    /// <summary>
    /// 生成/获取一个UI对象
    /// </summary>
    /// <param name="type">ui信息</param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        GameObject parent = GameObject.Find("Canvas");
        if (!parent)
        {
            Debug.LogError("Canvas不存在");
            return null;
        }
        if (dicUI.ContainsKey(type))
        {


            return dicUI[type];
        }
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path),parent.transform);
        ui.name = type.Name;
        dicUI.Add(type, ui);//把生成的UI加入字典
        return ui;  
    }
    /// <summary>
    /// 销毁一个Ui对象
    /// </summary>
    /// <param name="type"></param>
    public void DestoryUI(UIType type)
    {
        if (dicUI.ContainsKey(type))
        {
           GameObject.Destroy(dicUI[type]);
            dicUI.Remove(type);
        }
    }


}
