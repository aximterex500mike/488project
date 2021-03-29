using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
  
    public Transform Gun;

    Vector2 direction;
    
    public GameObject Bullet;

    public float BulletSpeed;

    public Transform ShootPoint;

    public float fireRate;

    float ReadyForNextShot;

    // ADDED FOR JOYSTICK
    public Joystick joystick;



    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {


        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(
        //    new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        //direction = (Vector2)mousePos - (Vector2)Gun.position;


        direction = joystick.Direction;
        faceMouse();
        if (joystick.Direction[0] > 0.02f || joystick.Direction[0] < -0.02f
            || joystick.Direction[1] > 0.02f || joystick.Direction[1] < -0.02f)
        {
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                shoot();
            }

        }

    }

    void faceMouse()
    {
        Gun.transform.right = direction;
    }

    void shoot()
    {
      GameObject BulletIns = Instantiate(Bullet,Gun.position,Gun.rotation);
      BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
      Destroy(BulletIns,2);
    }

}
