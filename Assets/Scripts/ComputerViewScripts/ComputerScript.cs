﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour
{
    /// <summary>
    /// 0 - MainMenu
    /// 1 - Stats
    /// 2 - Upgrades
    /// 3 - Help
    /// 4 - Restart
    /// 5 - Quit
    /// </summary>


    [SerializeField] private CanvasGroup[] Tabs;

    public int DisplayIndex = 0;

    public void Navigate(int btnIndex)
    {
        for (int i = 0; i < Tabs.Length; i++)
        {
            Tabs[i].gameObject.SetActive(i == btnIndex);
        }
    }
    public void GoBack()
    {
        Navigate(0);
    }
}