using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour {

    public GameObject PlayerMenuUI;
    public GameObject StartMenuUI;
    public GameObject ShopMenuUi;
    private GameManagerScript gm;

	// Use this for initialization
	void Start () {
        gm = GetComponent<GameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
