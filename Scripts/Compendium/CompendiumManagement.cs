using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompendiumManagement : MonoBehaviour {
    public static CompendiumManagement instance;

	// Use this for initialization
	void Start () {
        if(instance == null)
            instance = this;
	}
}
