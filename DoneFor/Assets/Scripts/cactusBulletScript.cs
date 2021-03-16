using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactusBulletScript : MonoBehaviour
{
    public int damage = 1;
    public float speed = 2;
    public bool isEnemyShot;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 bulletPath = speed*(GameObject.FindWithTag("Player").transform.position - transform.position).normalized;
        rb.velocity = new Vector2(bulletPath.x, bulletPath.y);
        Destroy(gameObject, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //do damage
        if (isEnemyShot)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //hurt health
                Destroy(gameObject);
            }
        }
    }

}
