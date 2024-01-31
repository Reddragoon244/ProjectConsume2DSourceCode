using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour {

    public PlayerCharacter player;
    public bool interaction = false;

    private BaseCharacter InteractCharacter;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InteractionAction(BaseCharacter character)
    {
        InteractCharacter = character;
        interaction = true;
    }
}
