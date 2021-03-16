using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int damage = 1;
    public float speed = 2;
    public bool isEnemyShot;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
        void Update()
        {
            transform.Translate((transform.forward * speed * Time.deltaTime));
        }
    }
}
