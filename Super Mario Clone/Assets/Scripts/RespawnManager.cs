using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

	private GameObject respawnPoint;
	private GameObject player;
    TimerManager timerManager;
	private GameObject camera;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		respawnPoint = GameObject.FindGameObjectWithTag ("RespawnPoint");
        timerManager = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerManager>();
		camera = GameObject.FindWithTag ("MainCamera");
	}

	public void RespawnPlayer()
	{
		Debug.Log ("Player Respawned");
		player.transform.position = respawnPoint.transform.position;
        timerManager.RestartTimer();
		camera.GetComponentInParent<CameraMovementScript> ().warpTo (player.transform.position.x, camera.transform.parent.position.y  /*camera.transform.localPosition.y*/);
    }
}
