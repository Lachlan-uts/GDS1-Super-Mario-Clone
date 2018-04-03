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

	//Timer Branch 
	GameObject player;
	PlayerBehaviourScript playerScript;
	private int enemyDamage = 1;
	RespawnManager respawnManager;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = player.GetComponent<PlayerBehaviourScript> ();
		respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			Debug.Log ("If Player is Small, Player Dies, if Player is Super lose a power up");

			if(playerScript.currentHealth <= 3 && playerScript.currentHealth != 0)
			{
				playerScript.takeDamage(enemyDamage);
				respawnManager.RespawnPlayer();

			}
			if (playerScript.currentHealth <= 0) {

				//Reload Application insert code here
				Destroy (other.gameObject);
                Debug.Log("ReloadScene");
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
		}
	}

	void Update () {

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

		if (hitWall)
			moveRight = !moveRight;

		if (moveRight)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			transform.localScale = new Vector3(1f, 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}
