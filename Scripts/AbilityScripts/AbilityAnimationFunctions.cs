using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityAnimationFunctions : MonoBehaviour
{
    public CombatCharacterStatus[] enemies = new CombatCharacterStatus[1];
    public CombatCharacterStatus cast;
    public BaseAbility ability;
    private Animator animator;
    private bool multi = false;
    private int repeatTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if(ability != null)
        {
            multi = ability.aoe;

            if(cast != null)
            {
                if(cast.tag == "Member")
                {
                    if(multi == true)
                    {
                        enemies = new CombatCharacterStatus[6];
                        enemies = FindObjectsOfType<EnemyStatus>();
                    }
                }

                if(cast.tag == "Enemy")
                {
                    enemies = new CombatCharacterStatus[4];

                    if(multi == true)
                        enemies = FindObjectsOfType<PlayerStatus>();
                    else    
                        enemies[0] = cast.GetComponent<AlphaEnemyCombat>().target.GetComponent<CombatCharacterStatus>();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
            animator.SetBool("Multi", multi);
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    public void DealDamage()
    {
        if(cast != null)
        {
            foreach(CombatCharacterStatus enemy in enemies)
            {
                if(enemy != null) {
                    //where we deal combat damage
                    enemy.takeDamage(cast.dealAbilityDamage(ability));
                }
            }    
        }
    }

    public void RepeatKeyFrame(int howManyTimes)
    {
        if(howManyTimes == repeatTimes)
        {
            animator.SetBool("Repeat", false);
        } else
        {
            repeatTimes++;
        }
    }
}
