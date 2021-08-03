using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 管理全局的一些东西
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot instance { get; private set; }
    /// <summary>
    /// 场景管理器
    /// </summary>
   public ISceneLoadManager SceneSystem { get; private set; }

    /// <summary>
    /// 显示一个面板
    /// </summary>
    public UnityAction<IBasePanel> Push { get; private set; }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        SceneSystem = new SceneLoadManager();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneSystem.SetScene(new StartScene());
    }
    /// <summary>
    /// 设置Pash
    /// </summary>
    /// <param name="push"></param>
    public void SetAction(UnityAction<IBasePanel> push)
    {
        Push = push;
    }

}
