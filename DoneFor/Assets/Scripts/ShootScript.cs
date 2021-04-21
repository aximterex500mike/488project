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

    public int gun;

    public float spread;

    public int count = 3;

    float ReadyForNextShot;

    // ADDED FOR JOYSTICK
    public Joystick joystick;

    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
        switch (gun){
            //revolver
            case 0:
                GameObject BulletIns = Instantiate(Bullet, Gun.position, Gun.rotation);
                BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
                audioManager.Play("Revolver");
                break;

            //shotgun
            case 1:
                GameObject BulletIns2 = Instantiate(Bullet, Gun.position, Gun.rotation);
                BulletIns2.GetComponent<Rigidbody2D>().AddForce(BulletIns2.transform.right * BulletSpeed);
                GameObject BulletIns3 = Instantiate(Bullet, Gun.position, Gun.rotation);
                BulletIns3.transform.transform.Rotate(0, 0, spread);
                BulletIns3.GetComponent<Rigidbody2D>().AddForce(BulletIns3.transform.right * BulletSpeed);
                GameObject BulletIns4 = Instantiate(Bullet, Gun.position, Gun.rotation);
                BulletIns4.transform.transform.Rotate(0, 0, spread*2);
                BulletIns4.GetComponent<Rigidbody2D>().AddForce(BulletIns4.transform.right * BulletSpeed);
                GameObject BulletIns5 = Instantiate(Bullet, Gun.position, Gun.rotation);
                BulletIns5.transform.transform.Rotate(0, 0, -spread);
                BulletIns5.GetComponent<Rigidbody2D>().AddForce(BulletIns5.transform.right * BulletSpeed);
                GameObject BulletIns6 = Instantiate(Bullet, Gun.position, Gun.rotation);
                BulletIns6.transform.transform.Rotate(0, 0, -(spread * 2));
                BulletIns6.GetComponent<Rigidbody2D>().AddForce(BulletIns6.transform.right * BulletSpeed);
                audioManager.Play("Shotgun");
                break;

            //bomb
            case 2:
                if (count > 0)
                {
                    GameObject BulletIns7 = Instantiate(Bullet, Gun.position, Gun.rotation);
                    count--;
                }
                break;
        }
    }

}
