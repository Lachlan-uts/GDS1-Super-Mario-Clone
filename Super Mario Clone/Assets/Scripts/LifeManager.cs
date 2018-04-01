using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
	
	PlayerBehaviourScript playerScript;
	GameObject player;
	private Text lifeText;
	public int currentLife;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = player.GetComponent<PlayerBehaviourScript> ();
		lifeText = GetComponent<Text> ();
		lifeText.text = "Life: " + playerScript.currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		currentLife = playerScript.currentHealth;
		UpdateLife ();
	}

	void UpdateLife()
	{
		if (lifeText != null) {
			lifeText.text = "Life: " + playerScript.currentHealth;

		}
	}
}
