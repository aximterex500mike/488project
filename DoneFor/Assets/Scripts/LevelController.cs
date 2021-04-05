using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelController : MonoBehaviour
{
    public int supply = 10;
    public int goal = 10;
    public int score = 0;
    public int coins = 0;
    public int level = 1;
    public int maxLevel = 1;
    public float spawnCD = 1;
    public float spawnCDtemp = 5;
    private Saver load;

    // Start is called before the first frame update

    private void Awake()
    {
        int num = FindObjectsOfType<LevelController>().Length;
        if (num != 1)
        {
            Destroy(this.gameObject);
        }
        // if more then one music player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(gameObject);
            load = SaveSystem.loadData();
            if (load != null)
            {
                coins = load.coins;
                maxLevel = load.level;
            }
        }
    }
    
    private void Update()
    {
        //controllers rate of spawn over all spawners
        spawnCDtemp -= Time.deltaTime;
    }
    public void addKill(int value)
    {
        score += value * 10;
        goal -= value;
        if (goal <= 0)
        {
            saveGame();
            SceneManager.LoadScene("LevelWon");
        }
        //add to score if they are not repeating a level

    }

    public void scorePenalty(int i)
    {
        score -= i;
    }

    public void playerDeath()
    {
        SceneManager.LoadScene("Death");
    }

    public void startFromLevel(int i)
    {
        //
        //set spawncd, temp, goal, supply
        //still need to figure out scaling
        //
        level = i;
        goal = (i * 5) + 10;
        supply = goal;
        spawnCDtemp = 5;
        spawnCD = 1 - (((float).025) * level);
        score = 0;
  
        if(level == 26)
        {
            //load win screen
            //SceneManager.LoadScene();
        }
        else if(level < 5)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (level < 10)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (level < 15)
        {
            SceneManager.LoadScene("Stage3");
        }
        else if (level < 20)
        {
            SceneManager.LoadScene("Stage4");
        }
        else
        {
            SceneManager.LoadScene("Stage5");
        }
    }

    public void getNextLevel()
    {
        //set up level scaling for next level
        level += 1;
        goal = (level * 5) + 10;
        supply = goal;
        spawnCDtemp = 5;
        spawnCD = 1 - (((float).025) * level);

        //return scene name to load
        if (level == 26)
        {
            //load win screen
            //SceneManager.LoadScene();
        }
        else if (level < 5)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (level < 10)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (level < 15)
        {
            SceneManager.LoadScene("Stage3");
        }
        else if (level < 20)
        {
            SceneManager.LoadScene("Stage4");
        }
        else
        {
            SceneManager.LoadScene("Stage5");
        }
    }

    public void saveGame()
    {
        SaveSystem.saveData(this);
    }
}
