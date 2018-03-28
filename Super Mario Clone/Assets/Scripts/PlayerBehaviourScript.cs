using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour {

	public float speed;

	private Rigidbody2D playerRB2D;

	// Use this for initialization
	void Start () {
		playerRB2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void FixedUpdate() {

		float move = Input.GetAxis("Horizontal");
		playerRB2D.velocity = new Vector2(move * speed, playerRB2D.velocity.y);
		
	}
}
