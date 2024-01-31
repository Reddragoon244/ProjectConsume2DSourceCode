using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour {

    public void ApplyStatus(CombatCharacter.status[] status, GameObject target)
    {
        foreach(CombatCharacter.status singleStatus in status)
        {
            switch (singleStatus)
            {
                case CombatCharacter.status.None:
                    statusNone(target);
                    break;
                case CombatCharacter.status.Burned:
                    statusBurned(target);
                    break;
                case CombatCharacter.status.Chilled:
                    statusChilled(target);
                    break;
                case CombatCharacter.status.Frozen:
                    statusFrozen(target);
                    break;
                case CombatCharacter.status.Cursed:
                    statusCursed(target);
                    break;
                case CombatCharacter.status.Protected:
                    statusProtected(target);
                    break;
                case CombatCharacter.status.Diseased:
                    statusDiseased(target);
                    break;
                case CombatCharacter.status.Shocked:
                    statusShocked(target);
                    break;
                case CombatCharacter.status.Nullified:
                    statusNullified(target);
                    break;
                case CombatCharacter.status.Silenced:
                    statusSilenced(target);
                    break;
                case CombatCharacter.status.Stunned:
                    statusStunned(target);
                    break;
                case CombatCharacter.status.Dead:
                    statusDead(target);
                    break;
            }
        }
        
    }
    void statusNone(GameObject charObject)
    {
        /*Status None*/
        for(int i=0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if(charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] != CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.None;
            }
        }
        Debug.Log("Status Manager None Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusBurned(GameObject charObject)
    {
        /*Status Burned: Damage over time*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Burned;
                break;
            }
        }
        Debug.Log("Status Manager Burned Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusChilled(GameObject charObject)
    {
        /*Status Chilled: Movement Slowed*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Chilled;
                break;
            }
        }
        Debug.Log("Status Manager Chilled Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusFrozen(GameObject charObject)
    {
        /*Status Frozen: Casting Slowed and Movement Slowed*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Frozen;
                break;
            }
        }
        Debug.Log("Status Manager Frozen Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusCursed(GameObject charObject)
    {
        /*Status Cursed: Casting Slowed*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Cursed;
                break;
            }
        }
        Debug.Log("Status Manager Cursed Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusProtected(GameObject charObject)
    {
        /*Status Protected: Protected from Negative Status*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Protected;
                break;
            }
        }
        Debug.Log("Status Manager Protected Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusDiseased(GameObject charObject)
    {
        /*Status Diseased: Damage over time, Movement Slowed, Casting Slowed*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Diseased;
                break;
            }
        }
        Debug.Log("Status Manager Diseased Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusShocked(GameObject charObject)
    {
        /*Status Shocked: Damage Dealt Reduced*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Shocked;
                break;
            }
        }
        Debug.Log("Status Manager Shocked Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusNullified(GameObject charObject)
    {
        /*Status Nullified: Remove Benefit Statuses*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Nullified;
                break;
            }
        }
        Debug.Log("Status Manager Nullified Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusSilenced(GameObject charObject)
    {
        /*Status Silenced: Can't Cast*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Silenced;
                break;
            }
        }
        Debug.Log("Status Manager Silenced Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusStunned(GameObject charObject)
    {
        /*Status Stunned: Can't Cast, Can't Move, Can't Control*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Stunned;
                break;
            }
        }
        Debug.Log("Status Manager Stunned Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
    void statusDead(GameObject charObject)
    {
        /*Status Dead*/
        for (int i = 0; i < charObject.GetComponentInChildren<CombatCharacterStatus>().status.Length; i++)
        {
            if (charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] == CombatCharacter.status.None)
            {
                charObject.GetComponentInChildren<CombatCharacterStatus>().status[i] = CombatCharacter.status.Dead;
                break;
            }
        }
        Debug.Log("Status Manager Dead Status for " + charObject.GetComponent<CombatCharacter>().characterName);
    }
}
