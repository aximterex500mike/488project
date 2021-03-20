using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int damage = 1;
    public float speed = 5;
    public bool isEnemyShot;
    public Vector2 Velocity;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 4);
    }
}
