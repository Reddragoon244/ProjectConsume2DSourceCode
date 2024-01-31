using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIspells : MonoBehaviour {

    public AbilityManagement abilmanagement;
    public ActiveAbilities activeAbilities;

    public RawImage[] imageUI = new RawImage[8];
	
	// Update is called once per frame
	void Update () {
		if(abilmanagement)
        {
            for (int i = 0; i < activeAbilities.activeAbilities.Length; i++)
            {
                if (activeAbilities.activeAbilities[i])
                {
                    imageUI[i].texture = activeAbilities.activeAbilities[i].UIicon.texture;
                }
            }
        }
	}
}
