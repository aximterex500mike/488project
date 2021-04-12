using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public int damage = 1000;
    public float radius = 2;
    public bool isEnemyShot = false;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject thing = collision.gameObject;
        if (thing.CompareTag("Enemy"))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, radius, 1 << LayerMask.NameToLayer("Enemy"));
            for (int i = 0; i < colliders.Length; i++)
            {
                GameObject enemyx = colliders[i].gameObject;
                if (enemyx.CompareTag("Enemy"))
                {
                    enemyx.GetComponent<Health>().takeDamage(damage);
                }
            }
            GameObject explode = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explode, 1);
            Destroy(gameObject);
        }
    }
}
