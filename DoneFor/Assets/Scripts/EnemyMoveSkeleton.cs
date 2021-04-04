/*
 * Skeleton
    * melee enemy 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveSkeleton : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    public float speed;
    public float attackDistance; // min. distance of attack 
    public float timeAttack; // time between attacks
    private bool attackMode;
    private bool cooldown; // enemy takes break after attack 
    private bool meleeRange; // in melee range of Player
    public Animator anim;
    private float timer;
    private bool faceRight;
    public float move;
    private float distance;
    

    void Awake()
    {
        timer = timeAttack;
        anim = GetComponent<Animator>();
    }
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        // speed = Random.Range(1f, 3f);
    }

    void Update()
    {
        if (move > 0 && !faceRight)
        {
            Flip();
        }
        else if (move < 0 && faceRight)
        {
            Flip();
        }
        
    }
    
    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180f, 0);
    }


    // collision with Player or Bullet 
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject thing = collision.gameObject;
        if (thing.CompareTag("Player"))
        {
            //do damage to players health
            //knock player back perhaps, maybe a blinking/damage animation
            //make player immune for a second or 2
        }
        if (thing.CompareTag("Bullet"))
        {
            if (!thing.transform.GetComponent<bulletScript>().isEnemyShot)
            {
                gameObject.transform.GetComponent<Health>().takeDamage(thing.transform.GetComponent<bulletScript>().damage);
                Destroy(thing);
            }
        }
        
    }
    
    void Skeleton()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > attackDistance)
        {
            Move();
            Stop(); 
        }
        
        else if (attackDistance >= distance && cooldown == false)
        {
            Attack(); 
        }

        if (cooldown)
        {
            Cooling();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("Walk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("SAttack"))
        {
            Vector2 playerPos = new Vector2(player.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timeAttack = timer;
        attackMode = true;
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
    }
    
    void Cooling()
    {
        timeAttack -= Time.deltaTime;
        if (timeAttack <= 0 && cooldown && attackMode)
        {
            cooldown = false;
            timeAttack = timer;
        }
    }

    void Stop()
    {
        cooldown = false;
        attackMode = false;
        anim.SetBool("Attack", false); 
    }

    public void StartCooldown()
    {
        cooldown = true; 
    }
    
    public void Shot()
    {
        anim.SetTrigger("SDeath");
    }

    private void Death()
    {
        Destroy(this.gameObject); 
    }

}

