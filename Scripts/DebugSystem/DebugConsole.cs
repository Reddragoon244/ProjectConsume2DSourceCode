using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour {
	public Text console;

	// Use this for initialization
	void Start () {
		if(console.gameObject.activeInHierarchy) {
			console.text = "";
		} else {
			console = null;
		}
	}
	
	public void writeToconsole(string text) {
		if(console != null) {
			if(console.gameObject.activeInHierarchy) {
				console.text = text;
			} 
		}
	}
}
