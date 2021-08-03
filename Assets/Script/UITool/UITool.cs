﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI管理工具，包括获取某个子对象组件的操作
/// </summary>
public class UITool {
    /// <summary>
    /// 获取当前活动面板
    /// </summary>
    GameObject activePanel;

    public UITool(GameObject panel)
    {
        activePanel = panel;
    }


    /// <summary>
    /// 给当前的活动面板获取或者添加一个组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns>组件</returns>
    public T GetOrAddComponent<T>() where T : Component
    {
        if (activePanel.GetComponent<T>() == null)
            activePanel.AddComponent<T>();

        return activePanel.GetComponent<T>();
    }
    /// <summary>
    /// 查找当前活动面板的组件
    /// </summary>
    /// <param name="name">子对象名字</param>
    /// <returns></returns>
    public GameObject FindChildGameObject(string name)
    {
        Transform[] trans = activePanel.GetComponentsInChildren<Transform>();

        foreach (Transform item in trans)
        {
            if (item.name == name)
            {
                return item.gameObject;
            }
        }
        Debug.LogWarning($"{activePanel.name}里找不到名为{name}的子对象");
        return null;
    }

    /// <summary>
    /// 根据名称获取一个子对象的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public T GetOrAddComponentInChildren<T>(string name)where T : Component
    {
        GameObject child = FindChildGameObject(name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
                child.AddComponent<T>();

            return child.GetComponent<T>();
        }
        return null;
    }
}
    


