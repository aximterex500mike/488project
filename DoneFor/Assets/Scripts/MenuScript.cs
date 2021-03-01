using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
   public void StartGame() {
       Application.LoadLevel("Stage1");
   }

   public void ToSettings() {
       Application.LoadLevel("SettingsMenu");
   }

   public void ToLevelSelection() {
       Application.LoadLevel("LevelSelection");
   }

   public void ToMainMenu() {
       Application.LoadLevel("MainMenu");
   }

   public void ToHighScore() {
       Application.LoadLevel("HighScoreMenu");
   }
}
