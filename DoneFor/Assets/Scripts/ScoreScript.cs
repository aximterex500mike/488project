using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text Score;
    GameObject controller;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + controller.transform.GetComponent<LevelController>().score; ;
    }
}
