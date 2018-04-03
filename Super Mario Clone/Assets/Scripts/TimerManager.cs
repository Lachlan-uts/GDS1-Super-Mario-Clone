using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour {
	public Text timerText;
	private float time = 1200;


	// Use this for initialization
	void Start () {
		StartCountdownTimer ();
		timerText = GetComponent<Text> ();
	}

	void StartCountdownTimer()
	{
		if (timerText != null) {
			time = 1200;
			timerText.text = "Time Left: 20:00:000";
			InvokeRepeating ("UpdateTimer", 0.0f, 0.01667f);
		}

	}

	void UpdateTimer()
	{
		if(timerText!= null)
		{time -= Time.deltaTime;
			string minutes = Mathf.Floor (time / 60).ToString ("00");
			string seconds = (time % 60).ToString("00");
				string fraction = ((time * 100) % 100).ToString("000");
				timerText.text = "Time Left: " + minutes + ":" + seconds + ":" + fraction;
		}
				}


	void Update()
	{
		if (time <= 0) {
			Destroy (GameObject.FindGameObjectWithTag("Player"));
		}
	}
    public void RestartTimer()
    {
        time = 1200;
        timerText.text = "Time Left: 20:00:000";

    }

}
