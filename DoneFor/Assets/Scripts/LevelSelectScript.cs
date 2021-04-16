using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public GameObject[] stagebuttons;
    GameObject controller;
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");

        //sets visible buttons based on max level
        int max = controller.GetComponent<LevelController>().maxLevel;
        for(int i = 0; i < 5; i++)
        {
            if(max > 0)
            {
                stagebuttons[i].SetActive(true);
            }
            max -= 5;
        }
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void S1()
    {
        controller.GetComponent<LevelController>().startFromLevel(1);
    }
    public void S2()
    {
        controller.GetComponent<LevelController>().startFromLevel(6);
    }
    public void S3()
    {
        controller.GetComponent<LevelController>().startFromLevel(11);
    }
    public void S4()
    {
        controller.GetComponent<LevelController>().startFromLevel(16);
    }
    public void S5()
    {
        controller.GetComponent<LevelController>().startFromLevel(21);
    }
}
