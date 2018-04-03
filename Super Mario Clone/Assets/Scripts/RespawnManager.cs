using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

	private GameObject respawnPoint;
	private GameObject player;
    TimerManager timerManager;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		respawnPoint = GameObject.FindGameObjectWithTag ("RespawnPoint");
        timerManager = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerManager>();
	}

	public void RespawnPlayer()
	{
		Debug.Log ("Player Respawned");
		player.transform.position = respawnPoint.transform.position;
        timerManager.RestartTimer();
    }
}
