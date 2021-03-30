using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public void submitScore()
    {
        //check score against high scores
        //if its qualifies insert
        //end print error and do nothing
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
