using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {

	// private variables
	private Rigidbody2D FB2DRB;

	// Use this for initialization
	void Start () {
		FB2DRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		} else {
			FB2DRB.AddForce (Vector2.up * 3, ForceMode2D.Impulse);
		}
	}
}
