using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour {


	private Rigidbody2D playerRB2D;

	// Use this for initialization
	void Start () {
		playerRB2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		//A simple test to help test if the camera will move with the player object.
		if (Input.anyKeyDown) {
			playerRB2D.AddForce (Vector2.right * 4,ForceMode2D.Impulse);
		}
	}
}
