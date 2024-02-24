using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimationFunctions : MonoBehaviour
{
    public Animator anim;
    public GameObject element = null;
    public Transform eleLocation = null;
    public bool BasicAttack;
    public bool HeavyAttack;
    public bool Dead;
    public bool KneelLight;
    public bool KneelHeavy;
    public bool Walk;
    public bool UseItem;
    public bool Victory;
    public bool Cast;
    public bool UltimateCast;
    public bool Casting;
    public bool Casted;
    public bool UltimateCasted;
    public bool Idle;
    public bool Stasis;
    public bool Spawn = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
        InitCombat();
    }
    void Update()
    {
        anim.SetFloat("Speed", GetComponentInParent<PlayerStatus>().haste);
        anim.SetBool("BasicAttack", BasicAttack);
        anim.SetBool("HeavyAttack", HeavyAttack);
        anim.SetBool("Dead", Dead);
        anim.SetBool("KneelLight", KneelLight);
        anim.SetBool("KneelHeavy", KneelHeavy);
        anim.SetBool("Walk", Walk);
        anim.SetBool("UseItem", UseItem);
        anim.SetBool("Victory", Victory);
        anim.SetBool("Cast", Cast);
        anim.SetBool("UltimateCast", UltimateCast);
        anim.SetBool("Casting", Casting);
        anim.SetBool("Casted", Casted);
        anim.SetBool("UltimateCasted", UltimateCasted);
        anim.SetBool("Stasis", Stasis);
        anim.SetBool("Idle", Idle);

        if(Spawn == true)
        {
            Instantiate(element, eleLocation.position, eleLocation.rotation);
            Spawn = false;
        }
    }
    void InitCombat()
    {
        BasicAttack = false;
        HeavyAttack = false;
        Dead = false;
        KneelLight = false;
        KneelHeavy = false;
        Walk = false;
        UseItem = false;
        Victory = false;
        Cast = false;
        UltimateCast = false;
        Casting = false;
        Casted = false;
        UltimateCasted = false;
        Stasis = false;
        Idle = true;
    }
    public void ActionEnd()
    {   
        InitCombat();
    }
    public void CastBegin()
    {
        Cast = false;
        Casting = true;
    }

    public void CastEnd()
    {
        Debug.Log("CAF in here");
        Cast = false;
        Casting = false;
        Casted = true;

        if(GetComponentInChildren<AlphaPlayerCombat>().abilityToCast != null) {
            GameObject abil = Instantiate(GetComponentInChildren<AlphaPlayerCombat>().abilityToCast.animations[0], GetComponent<AlphaPlayerCombat>().enemyTarget.GetComponentInChildren<BoxCollider2D>().transform.position, Quaternion.identity, GetComponent<AlphaPlayerCombat>().enemyTarget.GetComponentInChildren<BoxCollider2D>().transform);
            
            abil.GetComponent<AbilityAnimationFunctions>().cast = GetComponentInParent<CombatCharacterStatus>();

            //deal damage
            if(abil.GetComponent<AbilityAnimationFunctions>().ability.aoe != true)
                abil.GetComponent<AbilityAnimationFunctions>().enemies[0] = GetComponent<AlphaPlayerCombat>().enemyTarget.GetComponent<EnemyStatus>();
            
            GetComponentInChildren<AlphaPlayerCombat>().abilityToCast = null;
            GetComponent<AlphaPlayerCombat>().enemyTarget = null;
        }
    }
}
