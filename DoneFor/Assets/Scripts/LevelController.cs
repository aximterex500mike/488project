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
    public int maxLevel = 0;
    public float spawnCD = 1;
    public float spawnCDtemp = 5;
    public int[] levelScores = new int[30]; 

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
            Saver load = SaveSystem.loadData();
            if (load != null)
            {
                score = 0;
                coins = load.coins;
                maxLevel = load.level;
                goal = ((level - 1) * 5) + 10;
                supply = ((level - 1) * 5) + 10;
                spawnCD = 1 / (Mathf.Log(level + 1, 2));
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
        goal -= value;
        if (goal <= 0)
        {
            saveGame();
            SceneManager.LoadScene("LevelWon");
        }
        //add to score if they are not repeating a level
        if (level > maxLevel)
        {
            score += value * 10;
        }
    }

    public void playerDeath()
    {
        //reset data to before level start
        Saver load = SaveSystem.loadData();
        if (load != null)
        {
            score = 0;
            coins = load.coins;
            maxLevel = load.level;
            goal = ((level - 1) * 5) + 10;
            supply = ((level - 1) * 5) + 10;
            spawnCD = 1 / (Mathf.Log(level + 1, 2));
        }
        else
        {
            supply = 10;
            goal = 10;
            score = 0;
            coins = 0;
            level = 1;
            maxLevel = 0;
            spawnCD = 1;
            spawnCDtemp = 1;
        }
        //go to death screen
        SceneManager.LoadScene("Death");
    }

    public string getNextLevel()
    {
        saveGame();
        //set up level scaling for next level
        level += 1;
        goal = ((level - 1) * 5) + 10;
        supply = ((level - 1) * 5) + 10;
        spawnCD = 1 / (Mathf.Log(level + 1, 2));
        spawnCDtemp = 5;
        
        //return scene name to load
        if (level < 5)
        {
            return "Stage1";
        }
        else
        {
            return "Stage2";
        }
    }

    public void saveGame()
    {
        SaveSystem.saveData(this);
    }
}
