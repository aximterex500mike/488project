using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    public Vector2 speed = new Vector2(50, 50);
    public Animator animator;  //this animator is for walk animaion
    public float immunity = 3;

    public Joystick joystick;

    // 2 - Store the movement and the component
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    //private Transform cowboy;

    //Called once per frame
    void Update()
    {

        // Animation code
        animator.SetFloat("Horizontal", joystick.Horizontal);
        animator.SetFloat("Vertical", joystick.Vertical);

        if (joystick.Horizontal > 0.02f)
        {
            animator.SetFloat("isFacing", 1);
        }
        else if( joystick.Horizontal < - 0.02f)
        {
            animator.SetFloat("isFacing", -1);
        }

    }

    void FixedUpdate()
    {

        // 5 - Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        moveCharacter(); 
    }

    void moveCharacter(){//Vector2 direction) {

        // 3 - Retrieve axis information
        float inputX = joystick.Horizontal;
        float inputY = joystick.Vertical;

        // 4 - Movement per direction
        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        // 6 - Move the game object
        rigidbodyComponent.velocity = movement;

  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject thing = collision.gameObject;
        GameObject control = GameObject.FindWithTag("GameController");
        if (thing.CompareTag("Enemy"))
        {
            gameObject.transform.GetComponent<Health>().takeDamage(1);
            control.GetComponent<LevelController>().scorePenalty(0);
        }
        if (thing.CompareTag("Bullet"))
        {
            if (thing.transform.GetComponent<EnemyBulletScript>().isEnemyShot)
            {
                gameObject.transform.GetComponent<Health>().takeDamage(thing.transform.GetComponent<EnemyBulletScript>().damage);
                control.GetComponent<LevelController>().scorePenalty(0);
                Destroy(thing);
            }
        }
        //visual indicator of damage, set immunity

        
        // If player collides with coin, destroy 
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
        }
           
    }
}

