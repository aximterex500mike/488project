using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public static int Invulnerable = 0;
    public Vector2 speed = new Vector2(50, 50);
    public Animator animator;  //this animator is for walk animaion
    public float immunity = 3;
    public GameObject bullet;
    public GameObject sbullet;
    public GameObject bombdrop;
    public GameObject revolver;
    public GameObject shotgun;
    public GameObject bomb;
    GameObject controller;
    int[,] upgradeItems;

    private void Start()
    {
        //applies upgrades to weapons
        controller = GameObject.FindWithTag("GameController");
        upgradeItems = controller.GetComponent<LevelController>().upgradeItems;
        GameObject revolver = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        GameObject shotgun = gameObject.transform.GetChild(0).transform.GetChild(1).gameObject;
        GameObject bomb = gameObject.transform.GetChild(0).transform.GetChild(2).gameObject;
        revolver.GetComponent<ShootScript>().fireRate   = ((((float)0.4)* upgradeItems[3, 1]) + 4);
        bullet.GetComponent<bulletScript>().damage      = ((2*upgradeItems[3, 2])+10);
        shotgun.GetComponent<ShootScript>().fireRate    = ((((float)0.2) * upgradeItems[3, 3]) + 2);
        sbullet.GetComponent<bulletScript>().damage     = (upgradeItems[3, 4] + 5);
        bomb.GetComponent<ShootScript>().count          = (upgradeItems[3, 5] + 3);
        bombdrop.GetComponent<BombScript>().radius      = (2 + upgradeItems[3, 6]);
    }

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
         if(Invulnerable == 0){
        if (thing.CompareTag("Enemy"))
        {
            gameObject.transform.GetComponent<Health>().takeDamage(1);
            control.GetComponent<LevelController>().scorePenalty(20);
        }
        if (thing.CompareTag("Bullet"))
        {
            if (thing.transform.GetComponent<EnemyBulletScript>().isEnemyShot)
            {
                gameObject.transform.GetComponent<Health>().takeDamage(thing.transform.GetComponent<EnemyBulletScript>().damage);
                control.GetComponent<LevelController>().scorePenalty(20);
                Destroy(thing);
            }
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

