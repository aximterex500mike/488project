﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    public void PausePressed() {
        
        if(GameIsPaused) {
            Resume();
        } else {
            Pause();
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        //Debug.log("Loading menu..");
        SceneManager.LoadScene("MainMenu");
        if(GameIsPaused) {
            Resume();
        } else {
            Pause();
        }
    }

    public void QuitGame() {
        //Debug.log("Loading menu..");
        Application.Quit();
    }
}
