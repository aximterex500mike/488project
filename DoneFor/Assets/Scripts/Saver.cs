using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Saver
{
    public int level;
    public int coins;
    public int[] levelScores;
    //add weapons/ upgrade progress to save

    public Saver(LevelController lc)
    {
        if (lc.level > lc.maxLevel) {
        this.level = lc.level;
        }else{
            this.level = lc.maxLevel;
        }

        this.levelScores = lc.levelScores;
        if(lc.score > this.levelScores[level])
        {
            this.levelScores[level] = lc.score;
        }

        this.coins = lc.coins;

    }
}
