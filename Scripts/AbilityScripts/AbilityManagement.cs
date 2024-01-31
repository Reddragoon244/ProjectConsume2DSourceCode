using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManagement : MonoBehaviour {

    public AbilityList defaultLibrary;
    public AbilityList library;

	// Use this for initialization
	void Start () {
        if(library == null) {
            library = defaultLibrary;
            Debug.Log("library was null!");
        }
            
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddAbilitytoLibrary(BaseAbility ability)
    {
        /*Summary: add a new ability to the library*/
        library.library.Add(ability);
    }

    public BaseAbility SearchAbilityLibrary(BaseAbility ability)
    {
        /*Summary: Return ability that you are searching for*/
        BaseAbility searchAbil = null;

        searchAbil = library.library.Find(i => i.abilityName == ability.abilityName);

        return searchAbil;
    } 
}
