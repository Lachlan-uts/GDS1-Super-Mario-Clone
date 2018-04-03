using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeath : MonoBehaviour {

	PlayerBehaviourScript playerScript;
	private int enemyDamage = 1;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = player.GetComponent<PlayerBehaviourScript> ();
	}
	
	// Update is called once per frame

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
