using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 存储单个UI的信息，包括名字路径，读取res目录预设体
/// </summary>
public class UIPath
{
    /// <summary>
    /// UI名字
    /// </summary>
    /// <value></value>
   public string Name{get; private set;}
    /// <summary>
    /// UI路径
    /// </summary>
    /// <value></value>
   public string Path{get;private set;}


   public UIPath(string path){
       Path=path;
       Name= path.Substring(path.LastIndexOf('/')+1);
   }
}
