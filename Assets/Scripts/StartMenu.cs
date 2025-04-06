using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        this.gameObject.SetActive(false);
        GameManager.instance.menu.gameObject.SetActive(true);
        GameManager.instance.hud.gameObject.SetActive(true);
        GameManager.instance.ResumeGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}