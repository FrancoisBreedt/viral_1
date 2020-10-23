using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] AudioSource clickSound;

    public int DisplayIndex = 0;

    public void Navigate(int btnIndex)
    {
        clickSound.Play();
        for (int i = 0; i < Tabs.Length; i++)
        {
            Tabs[i].gameObject.SetActive(i == btnIndex);
        }
    }

    public void GoBack()
    {
        clickSound.Play();
        Navigate(0);
    }

    public void Restart()
    {
        clickSound.Play();
        GameManager.instance.Restart();
    }

}
