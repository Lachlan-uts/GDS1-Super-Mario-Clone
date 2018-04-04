using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviourScript : MonoBehaviour {

	public int typeOfPower = 0; // For reference: 0 = Mushroom, 1 = Fire Flower, 2 = 1-UP

	private Rigidbody2D powerupRB2D;

	// Use this for initialization
	void Start () {
		powerupRB2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BeginMovement() {
		if (typeOfPower == 0 || typeOfPower == 2) {
			powerupRB2D.AddForce (Vector2.right * 2, ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}
}
