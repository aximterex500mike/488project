using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Saver
{
    public int level;
    public int coins;
    public int[,] upgradeItems;

    public Saver(LevelController lc)
    {
        if (lc.level > lc.maxLevel) {
            this.level = lc.level;
        }else{
            this.level = lc.maxLevel;
        }
        this.coins = lc.coins;
        this.upgradeItems = lc.upgradeItems;
    }
}
