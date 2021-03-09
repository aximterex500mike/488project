/*
 * Enemy
     * each enemy has their own movement speed
     * added collision
     * direction towards Player
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    /*
    public GameObject player;  
    private Rigidbody2D rb;
    public float speed;
    private Vector3 direction;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        
        // each enemy can have their own movement speed
        speed = Random.Range(1f, 3f);
    }

    void Update()
    {
        EnemyFollow();
    }
    
    
    // collision with Player or Bullet 
    void OnTriggerEnter2D(Collider2D collision)
    {
        // if Enemy collides with Player, 
        switch "Player":
            EnemySpawn.spawning = false;
            // Didn't implement HP - so Player die in contact 
            Destroy(collision.gameObject);  
            player = null;
            yield break; 
        
        // if Bullet collides with Enemy, 
        switch "Bullet":
            // TODO: delete bullet object 
            // destroy enemy 
            Destroy(gameObject);
            yield break;
    }


    void EnemyFollow()
    {
        // if Player is alive
        if (player != null)
        {
            direction = (player.transform.position - transform.position).normalised;
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        // if Player is dead, Enemy stops: 
        else
            rb.velocity = Vector3.zero; 
    */
}