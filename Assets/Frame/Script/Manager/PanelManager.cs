using System.Collections.Generic;
using UnityEngine;

public interface IPanelManager
{
    /// <summary>
    /// UI的入栈操作，此操作会显示一个面板
    /// </summary>
    /// <param name="nextPanel">要显示的面板</param>
    void Push(IBasePanel nextPanel);
    /// <summary>
    /// 执行面板的出栈操作，此操作会执行面板的OnExit方法
    /// </summary>
    void Pop();
    /// <summary>
    /// 面板全部出栈此操作会执行面板的OnExit方法
    /// </summary>
    void PopAll();
    /// <summary>
    /// 返回存储面板实例的字典
    /// </summary>
    /// <returns></returns>
    Dictionary<UIPath, GameObject> Get_Dic();
   
}
/// <summary>
/// 面板管理器，用栈来存储UI
/// </summary>
public class PanelManager:IPanelManager
{
    /// <summary>
    /// 存储UI面板的栈
    /// </summary>
    private Stack<IBasePanel> stackPanel;
    /// <summary>
    /// 当前的UI管理器
    /// </summary>
    //private UIFrameManager UIManager;
    private IBasePanel panel;
    /// <summary>
    /// 存储所有UI信息的字典，每个UI信息都会对应一个GameObject
    /// </summary>
    private Dictionary<UIPath, GameObject> dicUI;

    public PanelManager()
    {
        stackPanel = new Stack<IBasePanel>();
        // UIManager = new UIFrameManager();
        dicUI = new Dictionary<UIPath, GameObject>();
    }
    public void Push(IBasePanel nextPanel)
    {
        if (stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnPause();
        }

        stackPanel.Push(nextPanel);

        nextPanel.Initialize(this);
        GameObject panelGo = nextPanel.GetSingleUI(nextPanel.UIPath);
        ///生成面板后，进行初始化操作
        nextPanel.Initialize(panelGo);
        nextPanel.OnEnter();
        //TOOD
    }
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
    public Dictionary<UIPath, GameObject> Get_Dic()
    {
        return dicUI;
    }
}
