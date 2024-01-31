using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilities : MonoBehaviour {

    public BaseAbility[] activeAbilities = new BaseAbility[8];
    public BaseAbility baseAttack = null;
    public BaseAbility selectedAbility = null;

    public void SelectAbilityFromLibrary(BaseAbility ability)
    {
        if (GetComponentInChildren<AbilityManagement>().SearchAbilityLibrary(ability) == ability)
        {
            selectedAbility = ability; 
        } else
        {
            Debug.Log("no spell in your library");
        }
    }

    public void AddActiveAbility(int position)
    {
        activeAbilities[position] = selectedAbility;
    }

    public void RemoveActiveAbility(int position)
    {
        activeAbilities[position] = null;
    }

    public void RemoveAllActiveAbilities()
    {
        for(int i = 0; i < activeAbilities.Length; i++)
        {
            Debug.Log(i);
            activeAbilities[i] = null;

        }
    }
}
