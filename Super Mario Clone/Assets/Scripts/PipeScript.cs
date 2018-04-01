using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour {

	// public variables
	public int entryAngle; // For reference: 0 = down, 1 = left, 2 = up, 3 = right
	public bool fixesCamera = false; // Will not fix camera position by default

	// private variables


	// serialized private variables
	[SerializeField]
	private Transform exitCoords;
	[SerializeField]
	private Vector2 exitCameraPos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enterPipe(GameObject enterant) {
		enterant.transform.position = exitCoords.position;
		if (enterant.tag == "Player") {
			GameObject.FindWithTag ("MainCamera").GetComponentInParent<CameraMovementScript> ().warpTo (exitCameraPos.x, exitCameraPos.y, fixesCamera);
		}
	}
}
