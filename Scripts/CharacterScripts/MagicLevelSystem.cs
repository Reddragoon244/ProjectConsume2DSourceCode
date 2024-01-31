using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLevelSystem : MonoBehaviour {

    public MagicLevel[] magicLevel;

    void loadMagicLevel(MagicLevel[] magicLoad)
    {
        magicLevel = magicLoad;
    }

    void gainMagicExp(BaseAbility.Abilitytype type)
    {
        foreach(MagicLevel magic in magicLevel)
        {
            if(magic.type == type)
            {
                magic.MagicExperienceGained(10);
            }
        }
    }

}
