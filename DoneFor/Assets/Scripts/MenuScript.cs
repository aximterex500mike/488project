using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject popup;
    GameObject controller;

    private void Start()
    {
        controller = GameObject.FindWithTag("GameController");
    }
    public void StartGame() {
        controller.GetComponent<LevelController>().startFromLevel(1);
   }

   public void ToSettings() {
        SceneManager.LoadScene("SettingsMenu");
   }

   public void ToLevelSelection() {
        SceneManager.LoadScene("LevelSelection");
   }

   public void ToMainMenu() {
        SceneManager.LoadScene("MainMenu");
   }

   public void ToHighScore() {
        SceneManager.LoadScene("HighScoreMenu");
   }

   public void confirmDelete()
    {
        popup.SetActive(true);
    }

    public void dontDelete()
    {
        popup.SetActive(false);
    }
   public void deleteData()
   {
        popup.SetActive(false);
        controller.GetComponent<LevelController>().deleteData();
        Debug.LogError("test1");
   }
}
