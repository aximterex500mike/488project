using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float rate = 3f;
    public float cooldown = 0;
    GameObject control;

    private void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {

        if (cooldown > 0)
        {

            cooldown -= Time.deltaTime;
        }
        if (cooldown <= 0)
        {
            if (control.transform.GetComponent<LevelController>().supply > 0)
            {
                if (control.transform.GetComponent<LevelController>().spawnCDtemp <= 0)
                {
                    control.transform.GetComponent<LevelController>().spawnCDtemp = control.transform.GetComponent<LevelController>().spawnCD;
                    cooldown = rate;
                    GameObject spawn = Instantiate(enemy, transform.position, Quaternion.identity);
                    control.transform.GetComponent<LevelController>().supply += 1;
                }
            }

        }
    }

}
