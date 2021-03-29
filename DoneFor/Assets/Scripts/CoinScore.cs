/*
 * Coin Score
    * updates when Player collects coin
    * shows score as text 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    public static CoinScore instance;
    public TextMeshProUGUI text;
    private int score;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void updateScore(int coinValue) // value of coin 
    {
        score += coinValue;
        text.text = "X" + score.ToString();
    }
}