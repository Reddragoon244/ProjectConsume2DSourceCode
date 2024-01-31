using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilityFunctions : MonoBehaviour
{
    public PlayerStatus[] players = new PlayerStatus[4];
    public EnemyStatus enemy;
    public BaseAbility ability;
    
    private Animator animator;
    private bool multi;

    // Start is called before the first frame update
    void Start()
    {
        multi = ability.aoe;
        animator = GetComponent<Animator>();

        if(multi == true)
            players = FindObjectsOfType<PlayerStatus>();
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
        if(enemy != null)
        {
            foreach(PlayerStatus player in players)
            {
                if(player != null)
                    player.takeDamage(enemy.dealPhysicalDamage());
            }    
        }
    }
}
