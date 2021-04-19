using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int ScoreVal = 0;
    GameObject controller;
    Text Score;
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + controller.GetComponent<LevelController>().score; ;
    }
}
