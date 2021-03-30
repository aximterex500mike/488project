using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWonMenuScript : MonoBehaviour
{
    GameObject controller;
    public GameObject menuDisplay;
    public GameObject upgradeDisplay;
    public GameObject settingsDisplay;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        menuDisplay.SetActive(true);
        upgradeDisplay.SetActive(false);
        settingsDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToSettings()
    {
        menuDisplay.SetActive(false);
        settingsDisplay.SetActive(true);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToUpgradeMenu()
    {
        menuDisplay.SetActive(false);
        upgradeDisplay.SetActive(true);
    }

    public void ToNextLevel()
    {
        SceneManager.LoadScene(controller.GetComponent<LevelController>().getNextLevel());
    }

    public void back()
    {
        menuDisplay.SetActive(true);
        upgradeDisplay.SetActive(false);
        settingsDisplay.SetActive(false);
    }
}
