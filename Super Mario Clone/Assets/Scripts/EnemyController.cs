using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float moveSpeed;
	private bool moveRight;

	public bool squash;
	public Transform squashCheck;
	private float squashCheckRadius = .2f;
	public LayerMask whatIsPlayer;
	

	// public Transform wallCheck;
	// private float wallCheckRadius = 0.1f;
	// public LayerMask whatIsWall;
	// private bool hitWall;

	// public bool grounded;
	// public Transform groundCheck;
	// public LayerMask whatIsGround;
	// float groundRadius = 0.1f;

	void OnStart(){

		squash = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player" && !squash){
			Debug.Log ("If Player is Small, Player Dies, if Player is Super lose a power up");
			Destroy (other.gameObject);
			//Have a manager to manage the respawn of the player
			//gameManager.RespawnPlayer ();
		}
		if (other.name == "Player" && squash){
			Destroy(gameObject);
		}
	}

	void Update () {

		squash = Physics2D.OverlapCircle(squashCheck.position, squashCheckRadius, whatIsPlayer);

		//grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		// hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

		// if (hitWall)
		// 	moveRight = !moveRight;

		// if (moveRight)
		// {
		// 	transform.localScale = new Vector3(-1f, 1f, 1f);
		// 	GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		// }
		// else
		// {
		// 	transform.localScale = new Vector3(1f, 1f, 1f);
		// 	GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		// }
	}
}
