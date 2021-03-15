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

        // 6 - Move the game object
        rigidbodyComponent.velocity = movement;
    }
}

