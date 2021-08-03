﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 面板管理器，用栈来存储UI
/// </summary>
public class PanelManager
{
    /// <summary>
    /// 存储UI面板的栈
    /// </summary>
    private Stack<BasePanel> stackPanel;
    /// <summary>
    /// UI管理器
    /// </summary>
    private UIManager UIManager;
    private BasePanel panel;
    
    public PanelManager()
    {
        stackPanel = new Stack<BasePanel>();
        UIManager = new UIManager();
    }
    /// <summary>
    /// UI的入栈操作，此操作会显示一个面板
    /// </summary>
    /// <param name="nextPanel">要显示的面板</param>
    public void Push(BasePanel nextPanel)
    {
        if (stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnPause();
        }

            stackPanel.Push(nextPanel);

        
            GameObject panelGo = UIManager.GetSingleUI(nextPanel.UIType);
            ///生成面板后，进行初始化操作
            nextPanel.Initialize(new UITool(panelGo));
            nextPanel.Initialize(this);
            nextPanel.Initialize(UIManager);
            nextPanel.OnEnter();
            //TOOD
    }
/// <summary>
/// 执行面板的出栈操作，此操作会执行面板的OnExit方法
/// </summary>
    public void Pop()
    {
        if (stackPanel.Count > 0)
        {
            stackPanel.Pop().OnExit();
        }
        if (stackPanel.Count > 0)
            stackPanel.Peek().OnResume();
    }

    public void PopAll()
    {
        while (stackPanel.Count > 0)
            stackPanel.Pop().OnExit();
    }
}
