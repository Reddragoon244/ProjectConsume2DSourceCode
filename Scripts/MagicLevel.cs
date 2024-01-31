using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class MagicLevel : ScriptableObject
{
    public AbilityList magicLibrary;
    public BaseAbility.Abilitytype type;

    public int magicLevel = 0;
    public int lvlcap = 999;
    public int currentExp;
    public int nextlvlExp = 100;

    public void MagicExperienceGained(int expFromtarget)
    {
        if(magicLevel != lvlcap)
        {
            currentExp = currentExp + expFromtarget;

            if (currentExp >= nextlvlExp)
            {
                magicLevel++;
                nextlvlExp = nextlvlExp + 100;

                if(magicLevel >= lvlcap)
                {
                    currentExp = 0;
                    nextlvlExp = 9999;
                }
            }
        }
    }
}
