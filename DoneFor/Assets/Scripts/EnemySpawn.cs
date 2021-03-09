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
    void Start()
    {
        spawning = true;
        // InvokeRepeating(string methodName, float time, float repeatRate)
        // Spawns every 1 second 
        InvokeRepeating("SpawnEnemy", 0f, 1f);  
    }

    void SpawnEnemy()
    {
        if (spawning)
        {
            randomSpawnPos = Random.Range(0, spawnPoint.Length);
            randomEnemy = Random.Range(0, enemy.Length);
            // Spawn random enemy and position 
            Instantiate(enemy[randomEnemy], spawnPoint[randomSpawnPos].position,
                Quaternion.identity);
        }
    }
}
