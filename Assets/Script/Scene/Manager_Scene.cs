using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 场景的状态管理系统
/// </summary>
public class Manager_Scene 
{
    /// <summary>
    /// 场景的状态类
    /// </summary>
    BaseScene sceneState;

    /// <summary>
    /// 设置当前场景并进入当前场景
    /// </summary>
    /// <param name="state"></param>
    public void SetScene(BaseScene state)
    {
        if (sceneState != null)
            sceneState.OnExit();
        sceneState = state;
        if (sceneState != null)
            sceneState.OnEnter();
    }
}
