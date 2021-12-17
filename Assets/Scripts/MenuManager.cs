using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager SharedInstance;
    public Canvas menuCanvas;
    public Canvas scoreCanvas;
    public Canvas gameOverCanvas;

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        menuCanvas.enabled = true;
        scoreCanvas.enabled = false;
        gameOverCanvas.enabled = false;
    }

    public void ShowMainMenu()
    {
        menuCanvas.enabled = true;
    }

    public void HideMainMenu()
    {
        menuCanvas.enabled = false;
    }

    public void ShowScoreMenu()
    {
        scoreCanvas.enabled = true;
    }

    public void HideScoreMenu()
    {
        scoreCanvas.enabled = false;
    }

    public void ShowGameOverMenu()
    {
        gameOverCanvas.enabled = true;
    }

    public void HideGameOverMenu()
    {
        gameOverCanvas.enabled = false;
    }

    public void ExitGameMenu()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
