using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneLoadManager
{
    /// <summary>
    /// 设置当前场景并进入当前场景
    /// </summary>
    /// <param name="state"></param>
    void SetScene(IBaseScene state);
}
/// <summary>
/// 场景的状态管理系统
/// </summary>
public class SceneLoadManager: ISceneLoadManager
{
    /// <summary>
    /// 场景的状态类
    /// </summary>
    IBaseScene sceneState;


    public void SetScene(IBaseScene state)
    {
        if (sceneState != null)
            sceneState.OnExit();
        sceneState = state;
        if (sceneState != null)
            sceneState.OnEnter();
    }
}
