using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeath : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Instant Death
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			Debug.Log ("Player Dies, Respawn and Lose 1 Life");
			Destroy (other.gameObject);
			//Have a manager to manage the respawn of the player
			//gameManager.RespawnPlayer ();
		}
}
}
