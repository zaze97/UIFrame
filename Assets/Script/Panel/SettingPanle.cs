using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanle : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SettingPanel";
    public SettingPanle() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("CLButton").onClick.AddListener(() =>
        {
            //点击事件的写入
            Debug.Log("按钮点击了");
            PanelManager.Pop();
        });
    }

}
