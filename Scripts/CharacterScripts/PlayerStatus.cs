using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CombatCharacterStatus {

    public float damage;
    public int currentExp;
    public int nextlvlExp;
    public PlayerCharacter playercharacter;
    private StatusManager statusmanager;
    private string statusString;
    // Use this for initialization
    void Start()
    {
        /*Stats*/
        Stats();
    }

    // Update is called once per frame
    void Update()
    {
        /*Status*/
        if (status[0] != CombatCharacter.status.None)
        {
            foreach (CombatCharacter.status stat in status)
            {
                statusString += stat + " ";
            }
            Debug.Log("Status of " + playercharacter.characterName + " (" + status + ")");
        }


        /*Death*/
        if (hpCurrent <= 0)
        {
            status[0] = CombatCharacter.status.Dead;

            if (status[0] == CombatCharacter.status.Dead)
            {
                Debug.Log("playercharacter is Dead");
            }

        }

        /*Mana*/
        if (manaCurrent <= 0)
        {
            Debug.Log("playercharacter is Out of Mana");
        }

    }

    public void Stats()
    {
        status = new CombatCharacter.status[5];
        status[0] = CombatCharacter.status.None;

        level = playercharacter.level;

        strength = playercharacter.strpoints;
        intellect = playercharacter.intpoints;
        defpoints = playercharacter.defensepoints;

        hpCap = playercharacter.healthpointCap;
        hpCurrent = playercharacter.healthpointCurrent;

        manaCap = playercharacter.manapointCap;
        manaCurrent = playercharacter.manapointCurrent;

        critical = playercharacter.criticalratio;
        haste = playercharacter.hasteratio;

        currentDamage = 0;
        DamageTaken = 0;

        GainEXP = playercharacter.GainEXP;
        
        currentExp = playercharacter.currentExp;
        nextlvlExp = playercharacter.nextlvlExp;
    }

    public void ExperienceGained(int ExperienceGained)
    {
        currentExp = currentExp + ExperienceGained;

        if(currentExp >= nextlvlExp)
        {
            int ran = (int)Random.Range(1.0f, 3.0f);

            level++;
            hpCap = hpCurrent = hpCap + (ran*10);
            ran = (int)Random.Range(1.0f, 3.0f);
            manaCap = manaCurrent = manaCap + (ran*5);
            ran = (int)Random.Range(2.0f, 5.0f);
            strength = strength + ran;
            ran = (int)Random.Range(2.0f, 5.0f);
            intellect = intellect + ran;
            ran = (int)Random.Range(1.0f, 3.0f);
            defpoints = defpoints + ran;

            nextlvlExp = nextlvlExp + (nextlvlExp/2);
            currentExp = nextlvlExp - currentExp;
        }
    }
    public void EquipmentAdd(EquipmentItem eqiupment)
    {
        hpCap = hpCurrent = hpCap + eqiupment.hp;
        defpoints = defpoints + eqiupment.defense;
        strength = strength + eqiupment.strength;
        intellect = intellect + eqiupment.intelligence;

        critical = critical + eqiupment.Critical;
        haste = haste + eqiupment.Haste;
    }
    public void EquipmentRemove(EquipmentItem eqiupment)
    {
        hpCap = hpCurrent = hpCap - eqiupment.hp;
        defpoints = defpoints - eqiupment.defense;
        strength = strength - eqiupment.strength;
        intellect = intellect - eqiupment.intelligence;

        critical = critical - eqiupment.Critical;
        haste = haste - eqiupment.Haste;
    }
}
