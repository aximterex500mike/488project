/*
 * Skeleton
    * melee enemy 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveSkeleton : MonoBehaviour
{

    private Transform player;
    private Rigidbody2D rb;
    public float speed;
    private Vector3 direction;
    public float cooldown = 0;
    public Animator animator;
    public double shootDist = 0.1;
    private double shootDelay = .5;
    private bool shot = false;



    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        // each enemy can have their own movement speed
        //speed = Random.Range(1f, 3f);
    }

    void Update()
    {
        if (player.position.x > transform.position.x)
        {
            animator.SetBool("Left", false);
        }
        if (player.position.x < transform.position.x)
        {
            animator.SetBool("Left", true);
        }
        if (shot)
        {
            if (shootDelay < 0)
            {
                shot = false;
            }
            else
            {
                shootDelay -= Time.deltaTime;
            }
        }
        EnemyFollow();
    }

    void EnemyFollow()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("SAttack") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("SAttack_L"))
        {
            animator.SetBool("Attack", false);
        }
        // if Player is alive
        if (player != null)
        {
            if (Vector2.Distance(player.position, transform.position) <= shootDist)
            {
                if (player.position.x > transform.position.x)
                {
                    animator.SetBool("Left", false);
                }
                else
                {
                    animator.SetBool("Left", true);
                }
                animator.SetBool("Move", false);
                animator.SetBool("Attack", true);
                rb.velocity = Vector3.zero;
                shot = true;
                shootDelay = .5;
            }
            else
            {
                animator.SetBool("Move", true);
                animator.SetBool("Attack", false);
                direction = (player.transform.position - transform.position).normalized;
                rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
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

}

