using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoresScript : MonoBehaviour
{
    public Text[] displays;
    public GameObject confirmBox;
    private void Start()
    {
        confirmBox.SetActive(false);
        displayScores();
    }
    // Start is called before the first frame update
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void displayScores()
    {
        string[] scores = SaveSystem.loadHighscores();
        int displayIndex = 0;
        for(int i =0; i < 10; i++)
        {
            string[] split = scores[i].Split(' ');
            displays[displayIndex].text = split[0];
            displays[displayIndex+1].text = split[1];
            displayIndex += 2;
        }
    }
    public void resetScores()
    {
        string[] defaultScores = { "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0" };
        SaveSystem.saveHighscores(defaultScores);
        confirmBox.SetActive(false);
        displayScores();
    }

    public void confirm()
    {
        confirmBox.SetActive(true);
    }

    public void dontReset()
    {
        confirmBox.SetActive(false);
    }
}
