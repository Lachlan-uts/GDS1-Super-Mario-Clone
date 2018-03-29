using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour {

	public float speed;
	public float baseSpeed;
	public float maxSpeed;
	public float jumpForce;
	public float jumpTime;
	public float jumpTimeCounter;
	public bool stoppedJumping;

	public bool grounded;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	float groundRadius = 0.1f;
 
	private Rigidbody2D playerRB2D;

	// Use this for initialization
	void Start () {

		playerRB2D = GetComponent<Rigidbody2D> ();
		jumpTimeCounter = jumpTime;
	}
	
	// Update is called once per frame
	void Update () {
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		if(grounded){
			jumpTimeCounter = jumpTime;
		}

		if(Input.GetMouseButtonDown(0)){
			if(grounded){
				playerRB2D.velocity = new Vector2(playerRB2D.velocity.x, jumpForce);
				stoppedJumping = false;
			}
		}

		if(Input.GetMouseButtonUp(0)){
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		while(Input.GetMouseButtonUp(1) && (speed > baseSpeed)){
			 speed -= 0.5f;
		}
	}

	void FixedUpdate() {

		float move = Input.GetAxis("Horizontal");
		if(Input.GetMouseButton(1) && speed < maxSpeed && grounded){
			speed += 0.5f;
		}
		
		playerRB2D.velocity = new Vector2(move * speed, playerRB2D.velocity.y);

		if((Input.GetMouseButton(0)) && !stoppedJumping)  {
            if(jumpTimeCounter > 0){
                playerRB2D.velocity = new Vector2 (playerRB2D.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
      
    }
}
