using UnityEngine;
using UnityEngine.UI;

public class SettingPanle : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SettingPanel";
    public SettingPanle() : base(new UIPath(path)) { }

    public override void OnEnter()
    {
        UITool.FindChild<Button>(activePanel, "CLButton").onClick.AddListener(() =>
         {
            //点击事件的写入
            Debug.Log("按钮点击了");
             PanelManager.Pop();
         });
    }

}
