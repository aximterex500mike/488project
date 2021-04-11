using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	
       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public Vector2 speed = new Vector2(50, 50);
    public Animator animator;

    // 2 - Store the movement and the component
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    void Update()
    {
	animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
	animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // 4 - Movement per direction
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

	if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1){
		animator.SetFloat("isFacing", Input.GetAxisRaw("Horizontal"));
	
	}
	//if(Input.GetAxisRaw("Horizontal") == -1){
	//	animator.SetFloat("lastMoveRight", Input.GetAxisRaw("Horizontal"));
	//} 
	

    }

    void FixedUpdate()
    {
        // 5 - Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

<<<<<<< Updated upstream
=======
        moveCharacter(); 
    }

    void moveCharacter(){//Vector2 direction) {
        //float inputX = 0;
        //float inputY = 0;

        //if (joystick.Horizontal >= 0.02f)
        //{
        //    inputX = speed.x;
        //}
        //else if (joystick.Horizontal <= -0.02f)
        //{
        //    inputX = -speed.x;
        //}

        //if (joystick.Vertical >= 0.02f)
        //{
        //    inputY = speed.y;
        //}
        //else if (joystick.Vertical <= -0.02f) {
        //    inputY = -speed.y;
        //}

        //movement = new Vector2(inputX, inputY);

        // 3 - Retrieve axis information
        float inputX = joystick.Horizontal;
        float inputY = joystick.Vertical;

        // 4 - Movement per direction
        movement = new Vector2(speed.x * inputX, speed.y * inputY);

>>>>>>> Stashed changes
        // 6 - Move the game object
        rigidbodyComponent.velocity = movement;
    }
}

