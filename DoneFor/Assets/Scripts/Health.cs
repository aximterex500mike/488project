using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 1;
    public int value = 1;
    private GameObject controller;
    public bool drop;
    public GameObject coin;
    public Transform dropPoint; 

    

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
         if (gameObject.CompareTag("Player"))
        {
            //adds health from upgrades
            hp = (controller.GetComponent<LevelController>().upgradeItems[3, 7] + 3);
            HUDHealth.HealthVal = hp;
            Invulnerability.HealthVal = hp;
        }
    }

    // Update is called once per frame
    public void takeDamage(int damage)
    {
        hp -= damage;
        if (gameObject.CompareTag("Enemy"))
        {
            ScoreScript.ScoreVal += 10;
        }
        if (gameObject.CompareTag("Player"))
        {
            HUDHealth.HealthVal = hp;
        }
        if(hp <= 0)
        {
            Instantiate(coin, gameObject.transform.position, gameObject.transform.rotation);
            if (gameObject.CompareTag("Player"))
            {
                controller.GetComponent<LevelController>().playerDeath();
                
            }
            if (gameObject.CompareTag("Enemy"))
            {
                controller.transform.GetComponent<LevelController>().addKill(value);
            }
            Destroy(gameObject);
        }
    }
}

