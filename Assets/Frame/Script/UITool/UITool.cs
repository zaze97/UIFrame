using UnityEngine;
/// <summary>
/// UI管理工具，包括获取某个子对象组件的操作
/// </summary>
public class UITool
{
    /// <summary>
    /// 给当前的活动面板获取或者添加一个组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns>组件</returns>
    public static T GetOrAddComponent<T>(GameObject activeGo) where T : Component
    {
        if (activeGo.GetComponent<T>() == null)
            activeGo.AddComponent<T>();

        return activeGo.GetComponent<T>();
    }
    /// <summary>
    /// 根据名称获取一个子对象的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public static T FindChild<T>(GameObject activeGo, string name)
    {
        Transform child = null;
        Transform[] children = activeGo.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name.Equals(name))
            {
                child = children[i];
                break;
            }
        }
        if (child != null)
        {
            return child.GetComponent<T>();
        }
        else
        {
            Debug.Log("未找到指定的组件，指定的组件为：" + typeof(T).FullName + "-----" + activeGo);
            return default(T);
        }
    }
}



