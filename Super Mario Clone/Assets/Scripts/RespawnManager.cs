using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

	private GameObject respawnPoint;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		respawnPoint = GameObject.FindGameObjectWithTag ("RespawnPoint");
	}

	public void RespawnPlayer()
	{
		Debug.Log ("Player Respawned");
		player.transform.position = respawnPoint.transform.position;
	}
}
