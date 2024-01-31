using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class CombinedAbility : BaseAbility {

    public BaseAbility[] abilities = new BaseAbility[3];

}


/*public BaseAbility[] abilities = new BaseAbility[5];

    public int abilitiesDamage = 0;
    public int abilitiesManaCost = 0;

    public virtual void CastAbility(CombatCharacter characterCaster, CombatCharacter target)
    {
        //needs to be in create ability//
        foreach (BaseAbility ability in abilities)
        {
            abilitiesManaCost += ((ability.manaUse*2) / 3);
            abilitiesDamage += ((ability.damage* 2) / 3);
        }
        
        if(characterCaster.manapoints >= abilitiesManaCost)
        {
            //Cast Ability//
            characterCaster.manapoints = characterCaster.manapoints - abilitiesManaCost;
        } else
        {
            Debug.Log(characterCaster.characterName + " does not have enough mana!!");
        }

    }*/
