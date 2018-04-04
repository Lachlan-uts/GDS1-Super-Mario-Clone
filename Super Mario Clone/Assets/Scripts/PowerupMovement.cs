using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMovement : MonoBehaviour {

       // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector2.right * 2 * Time.deltaTime);
    }

    /*public void BeginMovement()
    {
        if (typeOfPower == 0 || typeOfPower == 2)
        {
            powerupRB2D.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
            powerupRB2D.AddForce(Vector2.right * 2, ForceMode2D.Impulse);
        }
    }*/
}
