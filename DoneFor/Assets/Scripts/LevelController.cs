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
    public float spawnCDtemp = 1;
    
    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        Saver load = SaveSystem.loadData();
        if(load != null)
        {
            score = load.score;
            coins = load.coins;
            maxLevel = load.level;
            goal = ((level-1)*5) + 10;
            supply = ((level - 1) * 5) + 10;
            spawnCD = 1 / (Mathf.Log(level + 1, 2));
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
            level += 1;
            goal = ((level - 1) * 5) + 10;
            supply = ((level - 1) * 5) + 10;
            spawnCD = 1 / (Mathf.Log(level + 1, 2));

            //pick next scene to move to ( will be upgrade screen, then from there navigate to stage)
            if (level < 4)
            {
                SceneManager.LoadScene("Stage1");
            }
            else{
                SceneManager.LoadScene("Stage2");
            }
        }
        //add to score if they are not repeating a level
        if(level > maxLevel)
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
            score = load.score;
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
        SceneManager.LoadScene("Stage4");
    }

    public void saveGame()
    {
        SaveSystem.saveData(this);
    }
}
