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



    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
<<<<<<< Updated upstream
    {
      
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    direction = (Vector2)mousePos - (Vector2)Gun.position;
    faceMouse();

    if(Input.GetMouseButton(0)){
      if(Time.time > ReadyForNextShot)
      {
        ReadyForNextShot = Time.time + 1/fireRate;
        shoot();
      }
      
    }
=======
    {


        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(
        //    new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        //direction = (Vector2)mousePos - (Vector2)Gun.position;


        direction = joystick.Direction;
        faceJoy();
        if (joystick.Direction[0] > 0.5f || joystick.Direction[0] < -0.5f
            || joystick.Direction[1] > 0.5f || joystick.Direction[1] < -0.5f)
        {
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                shoot();
            }

        }
>>>>>>> Stashed changes

    }

    void faceJoy()
    {
        Gun.transform.right = direction;
    }

    void shoot()
    {
      GameObject BulletIns = Instantiate(Bullet,ShootPoint.position,ShootPoint.rotation);
      BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
      Destroy(BulletIns,2);
    }

}
