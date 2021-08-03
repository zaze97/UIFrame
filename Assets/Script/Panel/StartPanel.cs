using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/StartPanel";
    public StartPanel():base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("Button").onClick.AddListener(() =>
        {
            //点击事件的写入
            Debug.Log("按钮点击了");
           // PanelManager.Push(new SettingPanle());//简化
            Push(new SettingPanle());
        });


        UITool.GetOrAddComponentInChildren<Button>("Play").onClick.AddListener(() =>
        {
            GameRoot.instance.SceneSystem.SetScene(new MainScene());
        });
    }

}
