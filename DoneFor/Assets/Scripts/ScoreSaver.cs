using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreSaver
{
    public string[] scores;
    public ScoreSaver(string[] scores)
    {
        this.scores = scores;
    }
}
