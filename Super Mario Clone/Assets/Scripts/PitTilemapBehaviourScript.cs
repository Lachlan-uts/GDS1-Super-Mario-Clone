﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PitTilemapBehaviourScript : MonoBehaviour {

	Tilemap tilemap;

	// Use this for initialization
	void Start () {
		tilemap = this.GetComponent<Tilemap> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("this is " +this.name);
		ContactPoint2D[] contactP = new ContactPoint2D[1];
		collision.GetContacts(contactP);

		if (collision.gameObject.tag == "Player") {
			Debug.Log ("Player Dies, Respawn and Lose 1 Life");
			Destroy (collision.gameObject);
		}
	}
}
