using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {

    public GameManager gameManager;
    //public string deathMenu;
	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.name == "Player")
        {
            //SceneManager.LoadScene(deathMenu);
            gameManager.RespawnPlayer();
        }
    }
}
