/*
 * Enemy Spawner
    * Instructions:  
    * Need spawnpoint objects in the scene
    * Enemies will spawn on spawnpoint object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour

{
    public Transform[] spawnPoint; // Array of spawn points 
    public GameObject[] enemy;  // Array of enemy prefabs 
    int randomSpawnPos, randomEnemy;
    public static bool spawning;    // Spawn only when Player is alive 
    GameObject controller;
    public int limit = 10;
    public float cd = 2.0f;
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        limit = controller.GetComponent<LevelController>().goal;
        spawning = true;
        cd = controller.GetComponent<LevelController>().spawnCD;
        // InvokeRepeating(string methodName, float time, float repeatRate)
        // Spawns every 1 second 
        InvokeRepeating("SpawnEnemy", 0f, cd);  
    }

    void SpawnEnemy()
    {
        if (spawning)
        {
            limit--;
            if (limit <= 0)
            {
                spawning = false;
            }
            randomSpawnPos = Random.Range(0, spawnPoint.Length);
            randomEnemy = Random.Range(0, enemy.Length);
            // Spawn random enemy and position 
            Instantiate(enemy[randomEnemy], spawnPoint[randomSpawnPos].position,
                Quaternion.identity);
        }
    }
}
