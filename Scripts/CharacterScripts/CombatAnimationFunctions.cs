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
}
