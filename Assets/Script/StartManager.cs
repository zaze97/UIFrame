﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    PanelManager panelManager;
    private void Awake()
    {
        panelManager = new PanelManager();
    }

    void Start()
    {
        panelManager.Push(new StartPanel());
    }


}
