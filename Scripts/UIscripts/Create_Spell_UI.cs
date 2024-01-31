using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_Spell_UI : MonoBehaviour {

    public Button spellButton;
    public BaseAbility ability;

    private AbilityManagement abilman;
    private CreateAbilityManager createmana;

    void Start () {
        spellButton.GetComponent<RawImage>().texture = ability.UIicon.texture;
        spellButton.GetComponentInChildren<Text>().text = ability.abilityName;
        abilman = FindObjectOfType<AbilityManagement>();
        createmana = FindObjectOfType<CreateAbilityManager>();
    }

	// Use this for initialization
	void Update () {
		if(createmana.CanCreateAbility(ability.craftingMaterialsNeeded, ability))
        {
            spellButton.interactable = true;
        } else
        {
            spellButton.interactable = false;
        }

        if (abilman.library.library.Contains(ability))
        {
            Destroy(this);
        }
	}
}
