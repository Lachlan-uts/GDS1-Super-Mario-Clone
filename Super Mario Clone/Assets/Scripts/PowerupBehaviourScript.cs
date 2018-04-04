using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviourScript : MonoBehaviour {

	public int typeOfPower = 0; // For reference: 0 = Mushroom, 1 = Fire Flower, 2 = 1-UP

	private Rigidbody2D powerupRB2D;

	private Renderer rend;
	private bool disabled = true;

	// Use this for initialization
	void Start () {
		rend = this.GetComponent<Renderer> ();
		powerupRB2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rend.isVisible) {
			Debug.Log ("visable");
			if (disabled == true) {
				BeginMovement ();
			}
		}
		
	}

	public void BeginMovement() {
		if (typeOfPower == 0 || typeOfPower == 2) {
			powerupRB2D.AddForce (Vector2.right * 2, ForceMode2D.Impulse);
			disabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
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


			powerupRB2D.velocity = new Vector2(-2,powerupRB2D.velocity.y);
			//			enemyRB2D.AddForce (Vector2.left * 2, ForceMode2D.Impulse);
			Debug.Log (powerupRB2D.velocity);
		} else if (contacts [0].relativeVelocity.x > 0 && contacts[0].point.y > this.transform.position.y) {

			powerupRB2D.velocity = new Vector2(2,powerupRB2D.velocity.y);
			//			enemyRB2D.AddForce (Vector2.right * 2, ForceMode2D.Impulse);
		}
	}
}
