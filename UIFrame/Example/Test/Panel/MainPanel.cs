using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/MainPanel";
    public MainPanel() : base(new UIPath(path)) { }

    public override void OnEnter()
    {
        UITool.FindChild<Button>(activePanel, "Exit").onClick.AddListener(() =>
         {
            //点击事件的写入
            Debug.Log("按钮点击了");
             GameRoot.instance.SceneSystem.SetScene(new StartScene());

            //PanelManager.Pop();简化
            Pop();
         });


        //UITool.GetOrAddComponentInChildren<Button>("Play").onClick.AddListener(() =>
        //{
        //    GameRoot.instance.SceneSystem.SetScene(new MainScene());
        //});
    }
}
