using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class BaseAbility : ScriptableObject {

    public enum Abilitytype { Fire, Ice, Water, Electric, Earth, Dark, Light, Chaos, Void, Life, Death };
    public Abilitytype abilType;

    public string abilityName = null;
    public Sprite UIicon = null;
    public Transform[] targetPos = new Transform[3];/*0 = Head Position, 1 = Body Position, 2 = Feet Position*/
    public GameObject[] animations = new GameObject[3];
    public CombatCharacter.status[] AbilityEffects = new CombatCharacter.status[10];

    public InventoryItem[] craftingMaterialsNeeded = new InventoryItem[6];

    public int damage = 0;
    public int manaUse = 0;
    public bool aoe = false;
    public int levelRequired = 1;
    public string abilityDescription = "";
    public virtual void PlayerCastAbility(PlayerStatus caster, EnemyStatus target)
    {
        Debug.Log("cast " + abilityName);
        if(caster.manaCurrent >= manaUse)
        {
            /*Cast Ability*/
            caster.manaCurrent = caster.manaCurrent - manaUse;
            if (target.transform.GetChild(0).name == "Head Position")
            {
                targetPos[0] = target.transform.GetChild(0);
            }

            if (target.transform.GetChild(1).name == "Body Position")
            {
                targetPos[1] = target.transform.GetChild(1);                
            }

            if (target.transform.GetChild(2).name == "Feet Position")
            {
                targetPos[2] = target.transform.GetChild(2);
            }
            //edit with more damage from player
            target.takeDamage(damage + (int)caster.currentDamage);
            /*Cast Ability*/
        }
        else
        {
            Debug.Log(caster.playercharacter.characterName + " does not have enough mana!!");
        }
    }

    public virtual void EnemyCastAbility(EnemyStatus caster, PlayerStatus target)
    {
        Debug.Log("cast " + abilityName);
        if (caster.manaCurrent >= manaUse)
        {
            /*Cast Ability*/
            caster.manaCurrent = caster.manaCurrent - manaUse;
            if (target.transform.GetChild(0).name == "Head Position")
            {
                targetPos[0] = target.transform.GetChild(0);
            }

            if (target.transform.GetChild(1).name == "Body Position")
            {
                targetPos[1] = target.transform.GetChild(1);
            }

            if (target.transform.GetChild(2).name == "Feet Position")
            {
                targetPos[2] = target.transform.GetChild(2);
            }
            //edit with more damage from player
            target.takeDamage(damage + (int)caster.currentDamage);
            /*Cast Ability*/
        }
        else
        {
            Debug.Log(caster.character.characterName + " does not have enough mana!!");
        }
    }

    public virtual void ApplyStatustoEnemy(EnemyStatus target)
    {
        int i = 0;

        foreach(CombatCharacter.status status in AbilityEffects)
        {
            if(status != CombatCharacter.status.None)
            {
                foreach(CombatCharacter.status targetStatus in target.status)
                {
                    if(targetStatus == CombatCharacter.status.None)
                    {
                        target.status[i] = status;
                    }
                    i++;
                }
            }
        }
    }
    public virtual void ApplyStatustoPlayer(PlayerStatus target)
    {
        int i = 0;

        foreach (CombatCharacter.status status in AbilityEffects)
        {
            if (status != CombatCharacter.status.None)
            {
                foreach (CombatCharacter.status targetStatus in target.status)
                {
                    if (targetStatus == CombatCharacter.status.None)
                    {
                        target.status[i] = status;
                    }
                    i++;
                }
            }
        }
    }
}
