using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Main场景
/// </summary>
public class MainScene : BaseScene
{

    readonly string sceneName = "Main";
    PanelManager panelManager;
    public override void OnEnter()
    {
        panelManager = new PanelManager();
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            panelManager.Push(new StartPanel());
            GameRoot.instance.SetAction(panelManager.Push);//为了可以直接用pash
          //  GameRoot.instance.Push();
        }
    }
    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        panelManager.PopAll();
    }
    /// <summary>
    /// 加载场景完毕后执行的方法
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="load"></param>
    public void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        panelManager.Push(new MainPanel());
        Debug.Log($"{sceneName}场景加载完毕！");
    }
}
