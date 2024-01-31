using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacterStatus : MonoBehaviour {

    public CombatCharacter character;

    public int hpCurrent;
    public int hpCap;
    public int manaCurrent;
    public int manaCap;
    public int stamina;
    public int defpoints;
    public int strength;
    public int intellect;
    public float critical;
    public float critdamMod;
    public float haste;
    public float currentDamage;
    public float DamageTaken;
    public int GainEXP;
    public int level;
    public CombatCharacter.status[] status;
    public int dealPhysicalDamage() {
        currentDamage = strength;

        return (int)currentDamage;
    }
    public void takeDamage(int damage)
    {
        DamageTaken = damage - defpoints;

        hpCurrent = hpCurrent - (int)DamageTaken;
    }
    public void takeDamage(int damage, CombatCharacter.status statuses)
    {
        int i = 0;

        status[i++] = statuses;
        DamageTaken = damage - defpoints;

        hpCurrent = hpCurrent - (int)DamageTaken;

        DamageTaken = 0.0f;
    }

    public bool findStatus(CombatCharacter.status search) {
        foreach(CombatCharacter.status indivStatus in status) {
            if(indivStatus == search) {
                return true;
            }
        }
        return false;
    }
}
