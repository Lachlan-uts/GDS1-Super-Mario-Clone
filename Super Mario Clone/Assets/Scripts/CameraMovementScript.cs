using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour {

	// private variables
	private GameObject player;
	private Rigidbody2D player2DRB;
	private bool isFixed;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		player2DRB = player.GetComponent<Rigidbody2D> ();
		isFixed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isFixed && player != null) {
			if (player.transform.position.x > gameObject.transform.position.x) {
				gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, 
					new Vector2 (player.transform.position.x, gameObject.transform.position.y),
					player2DRB.velocity.x);
			}
		}
	}

	public void warpTo(float newX, float newY, bool newFixedStatus) {
		gameObject.transform.position = new Vector2 (newX, newY);

		isFixed = newFixedStatus;
	}

	public void warpTo(float newX, float newY) {
		gameObject.transform.position = new Vector2 (newX, newY);

	}
}
