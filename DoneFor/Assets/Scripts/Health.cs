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
    }

    void Update()
    {
        if (hp <= 0)
        {
            if (drop) Instantiate(coin, dropPoint.position, dropPoint.rotation);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    public void takeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
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

