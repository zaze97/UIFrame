using UnityEngine;

public interface IBasePanel
{
    /// <summary>
    /// UI信息
    /// </summary>
    UIPath UIPath { get; set; }
    /// <summary>
    /// 绑定这个面板的实例
    /// </summary>
    void Initialize(GameObject panelGo);
    /// <summary>
    /// 初始化面板管理器
    /// </summary>
    /// <param name="panelManager"></param>
    void Initialize(IPanelManager panelManager);
    /// <summary>
    /// 虚方法，UI进入时执行的操作，只会执行一次
    /// </summary>
    void OnEnter();
    /// <summary>
    /// 虚方法，UI暂停时执行的操作，只会执行一次
    /// </summary>
    void OnPause();
    /// <summary>
    /// 虚方法，UI继续时执行的操作，只会执行一次
    /// </summary>
    void OnResume();
    /// <summary>
    /// 虚方法，UI退出时执行的操作，只会执行一次
    /// </summary>
    void OnExit();
    /// <summary>
    /// 显示一个面板
    /// </summary>
    /// <param name="panel"></param>
    void Push(IBasePanel panel);
    /// <summary>
    /// 关闭一个面板
    /// </summary>
    void Pop();
    /// <summary>
    /// 生成/获取一个UI对象
    /// </summary>
    /// <param name="type">ui信息</param>
    /// <returns></returns>
    GameObject GetSingleUI(UIPath path);
    /// <summary>
    /// 销毁一个Ui对象
    /// </summary>
    /// <param name="type"></param>
    void DestoryUI(UIPath path);
}
/// <summary>
///所有UI面板的父类，包含UI面板的状态信息
/// </summary>
public abstract class BasePanel : IBasePanel
{
    /// <summary>
    /// UI信息
    /// </summary>
    public UIPath UIPath { get; set; }
    /// <summary>
    /// 面板管理器
    /// </summary>
    protected IPanelManager PanelManager { get; private set; }
    /// <summary>
    /// 获取当前活动面板
    /// </summary>
    protected GameObject activePanel { get; private set; }

    protected BasePanel(UIPath uIType)
    {
        UIPath = uIType;
    }

    public void Initialize(GameObject panelGo)
    {
        activePanel = panelGo;
    }

    public void Initialize(IPanelManager panelManager)
    {
        PanelManager = panelManager;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnPause()
    {
        UITool.GetOrAddComponent<CanvasGroup>(activePanel).blocksRaycasts = false;
    }

    public virtual void OnResume()
    {
        UITool.GetOrAddComponent<CanvasGroup>(activePanel).blocksRaycasts = true;
    }

    public virtual void OnExit()
    {
        DestoryUI(UIPath);
    }

    public void Push(IBasePanel panel) => PanelManager?.Push(panel);

    public void Pop() => PanelManager?.Pop();

    public GameObject GetSingleUI(UIPath path)
    {
        GameObject parent = GameObject.Find("Canvas");
        if (!parent)
        {
            Debug.LogError("Canvas不存在");
            return null;
        }
        if (PanelManager.Get_Dic().ContainsKey(path))
        {
            return PanelManager.Get_Dic()[path];
        }
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(path.Path), parent.transform);
        ui.name = path.Name;
        PanelManager.Get_Dic().Add(path, ui);//把生成的UI加入字典
        return ui;
    }

    public void DestoryUI(UIPath path)
    {
        if (PanelManager.Get_Dic().ContainsKey(path))
        {
            GameObject.Destroy(PanelManager.Get_Dic()[path]);
            PanelManager.Get_Dic().Remove(path);
        }
    }

}
