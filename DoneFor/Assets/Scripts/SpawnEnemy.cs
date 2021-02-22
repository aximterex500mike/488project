using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float rate = 3f;
    public int holds = 10;
    public float cooldown = 0;

    void Update()
    {
        if(holds == 0)
        {
            Destroy(gameObject);
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (cooldown <= 0)
        {
            holds--;
            cooldown = rate;
            GameObject spawn = Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }

}
