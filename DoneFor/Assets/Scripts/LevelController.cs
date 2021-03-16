using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int goal = 10;
    // Start is called before the first frame update
    


    public void addKill()
    {
        goal--;
        if (goal <= 0)
        {
            //move to win game screen.... implement later
        }
    }
}
