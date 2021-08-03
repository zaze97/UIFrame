﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景状态
/// </summary>
public abstract class BaseScene 
{
    /// <summary>
    /// 场景进入时侯执行的操作
    /// </summary>
    public abstract void OnEnter();
    /// <summary>
    /// 场景退出时执行的操作
    /// </summary>
    public abstract void OnExit();


}
