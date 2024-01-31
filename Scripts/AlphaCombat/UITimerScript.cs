using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimerScript : MonoBehaviour {
	public float currentTime, finishedTime;
	public AlphaPlayerCombat player;

	// Use this for initialization
	void Start () {
		currentTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTime < finishedTime) {
			currentTime = currentTime + Time.deltaTime;
			FindObjectOfType<DebugConsole>().writeToconsole(currentTime.ToString());
		} else {
			player.playerActive = true;
		}
	}
}
