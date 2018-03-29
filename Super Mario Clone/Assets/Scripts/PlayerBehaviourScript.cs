using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour {

	// serialized private variables
	[SerializeField]
	private GameObject fireball;

	// private variables
	private Rigidbody2D playerRB2D;

	private int healthState;

	private int livesCount;

	private bool facingRight;

	// Use this for initialization
	void Start () {
		playerRB2D = GetComponent<Rigidbody2D> ();
		healthState = 0; // In short, take a single hit, death ensues
		livesCount = 3;
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		//A simple test to help test if the camera will move with the player object.
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			playerRB2D.AddForce (Vector2.right * 4,ForceMode2D.Impulse);
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			Debug.Log ("Z");
			if (healthState >= 2) {
				CreateFireball ();
				Debug.Log ("Fire ball");
			}
		}
	}

	void CreateFireball() {
		GameObject newFireball = Instantiate (fireball, gameObject.transform.position, Quaternion.identity) as GameObject;
		if (facingRight) {
			newFireball.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 3.0f, ForceMode2D.Impulse);
		} else {
			newFireball.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 3.0f, ForceMode2D.Impulse);
		}

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Powerup") { // If the player comes into contact with a powerup
			Debug.Log("CollisionWithPowerup");
			if (healthState == 0 && other.gameObject.GetComponent<PowerupBehaviourScript> ().typeOfPower == 0) {
				healthState++;
				Debug.Log ("Mushroom");
			} else if (healthState < 2 && other.gameObject.GetComponent<PowerupBehaviourScript> ().typeOfPower == 1) {
				healthState = 2;
				Debug.Log ("Fire Flower");
			} else if (other.gameObject.GetComponent<PowerupBehaviourScript> ().typeOfPower == 2) {
				livesCount++;
				Debug.Log ("1-UP");
			}

		}
	}
}
