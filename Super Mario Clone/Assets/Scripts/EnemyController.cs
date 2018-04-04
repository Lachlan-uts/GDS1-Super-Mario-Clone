using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float moveSpeed;
	private bool moveRight;

	public Transform wallCheck;
	private float wallCheckRadius = 0.1f;
	public LayerMask whatIsWall;
	private bool hitWall;

	public bool grounded;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	float groundRadius = 0.1f;



	private Rigidbody2D enemyRB2D;

	void Start () {
		enemyRB2D = GetComponent<Rigidbody2D> ();
	}

	public void BeginMovement() {
			enemyRB2D.AddForce (Vector2.left * 2, ForceMode2D.Impulse);
	}

	void OnCollisionEnter2D(Collision2D other) {


		ContactPoint2D[] contacts = new ContactPoint2D[4];
		int contactsLength = other.GetContacts (contacts);
		Debug.Log ("contact length = " + contactsLength);
		//contacts. other.GetContacts;

		Debug.Log ("contacted");
		foreach (ContactPoint2D contact in contacts) {
			Debug.DrawRay (contact.point, contact.normal, Color.white, 4.0f);
			Debug.Log ("contacted and foreached");
		}
	}

	//Ye olde stuff
//	void OnTriggerEnter2D(Collider2D other)
//	{
//		if (other.name == "Player") {
//			Debug.Log ("If Player is Small, Player Dies, if Player is Super lose a power up");
//			Destroy (other.gameObject);
//			//Have a manager to manage the respawn of the player
//			//gameManager.RespawnPlayer ();
//		}
//	}
//
//	void Update () {
//
//		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
//
//		hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
//
//		if (hitWall)
//			moveRight = !moveRight;
//
//		if (moveRight)
//		{
//			transform.localScale = new Vector3(-1f, 1f, 1f);
//			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
//		}
//		else
//		{
//			transform.localScale = new Vector3(1f, 1f, 1f);
//			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
//		}
//	}
}
