using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	private Renderer rend;
	private Camera cam;
	private Plane[] planes;
	private bool disabled = true;

	private Rigidbody2D enemyRB2D;

	GameObject player;
	PlayerBehaviourScript playerScript;
	private int enemyDamage = 1;

	void Start () {
		cam = Camera.main;
		planes = GeometryUtility.CalculateFrustumPlanes (cam);
		rend = this.GetComponent<Renderer> ();
		enemyRB2D = GetComponent<Rigidbody2D> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = player.GetComponent<PlayerBehaviourScript> ();
	}

	void Update() {
		if (rend.isVisible) {
			Debug.Log ("visable");
			if (disabled == true) {
				BeginMovement ();
			}
		}
		Debug.Log (enemyRB2D.velocity);
	}

	public void BeginMovement() {
		enemyRB2D.AddForce (Vector2.left * 2, ForceMode2D.Impulse);
		disabled = false;
		Debug.Log (enemyRB2D.velocity);
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.tag == "Player") {
			Debug.Log ("If Player is Small, Player Dies, if Player is Super lose a power up");
			if (playerScript.currentHealth != 0) {
                playerScript.takeDamage(enemyDamage);
			}

			if (playerScript.currentHealth <= 0) {
				//Reload Application insert code here
				Destroy (other.gameObject);
                Debug.Log("ReloadScene");
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
			//Destroy (other.gameObject);
			//Have a manager to manage the respawn of the player
			//gameManager.RespawnPlayer ();
		}

		ContactPoint2D[] contacts = new ContactPoint2D[4];
		int contactsLength = other.GetContacts (contacts);
		Debug.Log ("contact length = " + contactsLength);
		//contacts. other.GetContacts;



		Debug.Log ("contacted");
		foreach (ContactPoint2D contact in contacts) {
			Debug.DrawRay (contact.point, contact.normal, Color.white, 4.0f);
			Debug.Log (contact.relativeVelocity.x);
			Debug.Log ("the contact normal " + contact.normal);
			Debug.Log ("the contact point " + contact.point);
		}
		if (contacts [0].relativeVelocity.x < 0 && contacts[0].point.y > this.transform.position.y) {
			Debug.Log ("trying to change velocity");
			//enemyRB2D.velocity.Set (-(contacts [0].relativeVelocity.x), enemyRB2D.velocity.y);


			enemyRB2D.velocity = new Vector2(-2,enemyRB2D.velocity.y);
//			enemyRB2D.AddForce (Vector2.left * 2, ForceMode2D.Impulse);
			Debug.Log (enemyRB2D.velocity);
		} else if (contacts [0].relativeVelocity.x > 0 && contacts[0].point.y > this.transform.position.y) {

			enemyRB2D.velocity = new Vector2(2,enemyRB2D.velocity.y);
//			enemyRB2D.AddForce (Vector2.right * 2, ForceMode2D.Impulse);
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
