/*
 * Coin Script
    * set value of coin
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int coinValue = 1; // value of coin 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinScore.instance.updateScore(coinValue);
            Destroy(this.gameObject);
        }
    }
}
