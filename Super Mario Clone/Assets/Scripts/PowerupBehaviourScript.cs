using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviourScript : MonoBehaviour {

    public GameObject mushroom;
    public GameObject fireFlower;

    public int levelOfPower = 0; // For reference: 0 = Mushroom, 1 = Fire Flower, 2 = 1-UP
    private int counter;

	

	// Use this for initialization
	void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CounterCheck()
    {
        return counter == 0;
    }

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player" && CounterCheck() && other.gameObject.GetComponent<PlayerBehaviourScript>().HealthCheck() == 0) {
            Instantiate(mushroom, this.gameObject.GetComponentInChildren<Transform>().transform);
            counter++;
        }
        else if (other.gameObject.tag == "Player" && CounterCheck() && other.gameObject.GetComponent<PlayerBehaviourScript>().HealthCheck() == 1)
        {
            Instantiate(fireFlower, this.gameObject.GetComponentInChildren<Transform>().transform);
            counter++;
        }
	}


}
