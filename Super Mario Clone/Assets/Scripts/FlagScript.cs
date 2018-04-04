using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {

	// Serialized private variables
	[SerializeField]
	private GameObject flagTop;
	[SerializeField]
	private GameObject flagBottom;

	// private variables
	private GameObject player;
	private Collider2D collider;
	private int sequenceState;
	private float flagSpeed;
	private float curTime;
	private float endTime;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		collider = gameObject.GetComponent<Collider2D> ();
		sequenceState = 0;
		flagSpeed = 0.1f;
		curTime = 0.0f;
		endTime = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (sequenceState == 1) {
			Debug.Log ("Flag Sequence Begins");
			player.transform.position = Vector3.MoveTowards (player.transform.position, flagBottom.transform.position, flagSpeed);
			flagTop.transform.position = Vector3.MoveTowards (flagTop.transform.position, flagBottom.transform.position, flagSpeed);
			if (player.transform.position.Equals (flagBottom.transform.position) && flagTop.transform.position.Equals (flagBottom.transform.position)) {
				sequenceState = 2;
				Debug.Log ("Part 2 Start");
			}
		} else if (sequenceState == 2) {
			Debug.Log ("Part 3 Start");
			sequenceState = 3;
			player.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 2.4f, ForceMode2D.Impulse);
		} else if (sequenceState == 3) {
			Debug.Log ("Part 4 Start");
			sequenceState++;
			player.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 2.0f, ForceMode2D.Impulse);
		} else if (sequenceState == 4) {
			curTime += Time.deltaTime;
			if (curTime >= endTime) {
				Debug.Log ("Part 5 Start");
				sequenceState = 5;
			}
		} else if (sequenceState == 5) {
			Debug.Log ("End Of Level");
			player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
			sequenceState = 6;
		}
		
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.Equals (player)) {
			collider.enabled = false;
			sequenceState = 1;
			player.GetComponent<PlayerBehaviourScript> ().enabled = false;
			player.transform.position = new Vector2(flagBottom.transform.position.x, player.transform.position.y);
			Debug.Log ("Hello Player");
		}
	}


}
