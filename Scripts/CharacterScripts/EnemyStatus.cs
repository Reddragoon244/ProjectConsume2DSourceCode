using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : CombatCharacterStatus {

    public int spawnlocation = 0;

    public BaseAbility basicAbility;
    public BaseAbility[] abilities = new BaseAbility[4];
    public InventoryItem[] enemyTable;

    private string statusString;
    void Start()
    {
        status = new CombatCharacter.status[5];
        status[0] = CombatCharacter.status.None;

        defpoints = character.defensepoints;
        strength = character.strpoints;
        intellect = character.intpoints;

        hpCap = character.healthpointCap + (stamina * 10);
        hpCurrent = character.healthpointCurrent + (stamina * 10);

        manaCap = character.manapointCap + (intellect * 5);
        manaCurrent = character.manapointCurrent + (intellect * 5);

        critical = character.criticalratio;
        haste = character.hasteratio;
        GainEXP = character.GainEXP;

        level = character.level;

        enemyTable = new InventoryItem[character.lootSize];

        if (FindObjectOfType<GameManagerScript>().inCombat == true)
        {
            GetComponentInChildren<Animator>().SetTrigger("Combat");
            FindObjectOfType<AlphaEndCombatScript>().Allexp += GainEXP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(character) {
            /*Status*/
            foreach (CombatCharacter.status status in status)
            {
                if (status == CombatCharacter.status.Dead)
                {
                    /*Multiplayer Not Implemented*/
                    /*Run a What to do if status function here*/
                    Debug.Log("Enemy is Dead");
                    Destroy(this.gameObject);
                    break;
                }
            }

            /*Death*/
            if (hpCurrent <= 0 )
            {
                status[0] = CombatCharacter.status.Dead;

                if (status[0] == CombatCharacter.status.Dead)
                {
                    /*Multiplayer Not Implemented*/
                    //FindObjectOfType<PlayerStatus>().ExperienceGained(GainEXP);
                    Debug.Log("Enemy is Dead");
                    Destroy(this.gameObject);
                }

            }
            if(manaCap != 0)
            {
                if (manaCurrent <= 0)
                {
                    Debug.Log("Enemy is Out of Mana");
                }
            }
        }
    }
}
