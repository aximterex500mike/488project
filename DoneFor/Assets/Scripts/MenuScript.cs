using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   public void StartGame() {
        SceneManager.LoadScene("Stage1");
   }

   public void ToSettings() {
       //Application.LoadLevel("SettingsMenu");
   }

   public void ToLevelSelection() {
        SceneManager.LoadScene("LevelSelection");
    }

   public void ToMainMenu() {
       //Application.LoadLevel("MainMenu");
   }

   public void ToHighScore() {
       //Application.LoadLevel("HighScoreMenu");
   }

    public void DeleteData()
    {

    }
}
