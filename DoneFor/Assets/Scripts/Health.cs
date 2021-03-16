using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 1;
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
    }
    // Update is called once per frame
    public void takeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Player"))
            {

            }
            if (gameObject.CompareTag("Enemy"))
            {
                controller.transform.GetComponent<LevelController>().addKill();
            }
        }
    }
}
