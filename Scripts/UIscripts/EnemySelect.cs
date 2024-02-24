using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelect : MonoBehaviour
{
    public GameObject enemy, enemyselects;
    public PlayerStatus player;
    public BaseAbility ability, basicattack;
    public int enemyNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        player = FindObjectOfType<CombatMenu>().member;

        if(FindObjectOfType<CombatMenuBasicAttack>())
            basicattack = FindObjectOfType<CombatMenuBasicAttack>().basicAttack;

        if (FindObjectOfType<AlphaCombatManager>().combatcharacterlist.Count < enemyNumber)
            this.gameObject.SetActive(false);
        else
        {
            enemy = enemy.GetComponentInChildren<EnemyStatus>().gameObject;
            FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {

    }

    public void TargetButton() 
    {
        if(FindObjectOfType<CombatMenuAbility>())
            ability = FindObjectOfType<CombatMenuAbility>().ability;
        
        if(ability != null) {
            TargetAbility(ability);
            FindObjectOfType<CombatMenuAbility>().ability = null;
        } else {
            player.GetComponentInChildren<CombatAnimationFunctions>().BasicAttack = true;
            GameObject abil = Instantiate(basicattack.animations[0], enemy.GetComponentInChildren<BoxCollider2D>().transform.position, Quaternion.identity, enemy.GetComponentInChildren<BoxCollider2D>().transform);
            
            abil.GetComponent<AbilityAnimationFunctions>().cast = player;

            //deal damage
            if(abil.GetComponent<AbilityAnimationFunctions>().ability.aoe != true)
                abil.GetComponent<AbilityAnimationFunctions>().enemies[0] = enemy.GetComponent<EnemyStatus>();

            enemyselects.SetActive(false);
        }
    }

    public void TargetAbility(BaseAbility ability) {
        Debug.Log("in here");
        player.GetComponentInChildren<CombatAnimationFunctions>().Cast = true;
        player.GetComponentInChildren<AlphaPlayerCombat>().enemyTarget = enemy;
        player.GetComponentInChildren<AlphaPlayerCombat>().abilityToCast = ability;
        enemyselects.SetActive(false);
    }
}
