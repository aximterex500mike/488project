﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenuScript : MonoBehaviour
{
    GameObject controller;
    public Text scoreDisplay;
    public Text messageDisplay;
    public Text endMessage;
    public InputField aname;
    public GameObject submitButton;
    private void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        int playerScore = controller.GetComponent<LevelController>().score;
        scoreDisplay.text = ("Score: " + playerScore.ToString());
        int lvl = controller.GetComponent<LevelController>().level;
        if(lvl > 25)
        {
            endMessage.text = "You Won!";
        }

    }
    public void submitScore()
    {
        ///////////////////////////////get name here
        /////name
        string scoreName = aname.text;
        if (scoreName.Length < 3 || scoreName.Length > 12 || scoreName.Contains(" "))
        {
            messageDisplay.text = "Invalid name";
        }
        else
        {
            int currentScore = controller.GetComponent<LevelController>().score;
            //check score against high scores
            string[] scores = SaveSystem.loadHighscores();
            string tempscore = "";
            int index = 0;
            bool submit = false;
            for (int i = 0; i < scores.Length; i++)
            {
                string[] split = scores[i].Split(' ');
                messageDisplay.text = (split[1]);
                if (currentScore > int.Parse(split[1]))
                {
                    tempscore = scores[i];
                    scores[i] = scoreName + " " + currentScore.ToString();
                    index = i + 1;
                    submit = true;
                    break;
                }
            }
            string temp2 = "";
            for (int i = index; i < scores.Length; i++)
            {
                temp2 = scores[i];
                scores[i] = tempscore;
                tempscore = temp2;
            }
            if (submit)
            {
                SaveSystem.saveHighscores(scores);
                messageDisplay.text = ("Score submitted! Your rank is " + index.ToString());
                submitButton.SetActive(false);
            }
            else
            {
                messageDisplay.text = "Score too low";
            }
        }
    }

    public void toMainMenu()
    {
        controller.GetComponent<LevelController>().score = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
