﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaPlayerCombat : MonoBehaviour {
	public GameObject enemyTarget;
	public BaseAbility abilityToCast;
	public float currentTime, finishedTime;
	public bool playerActive = false;

	// Use this for initialization
	void Start () {
		currentTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTime < finishedTime) {
			currentTime = currentTime + Time.deltaTime;
		} else {
			playerActive = true;
		}
	}

	public void AfterTurn() {
		playerActive = false;
		currentTime = 0.0f;
	}
}
