using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelect : MonoBehaviour
{
    public GameObject enemy, enemyselects;
    public PlayerStatus player;
    public BaseAbility ability;
    public int enemyNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        player = FindObjectOfType<CombatMenu>().member;

        if(FindObjectOfType<CombatMenuBasicAttack>())
            ability = FindObjectOfType<CombatMenuBasicAttack>().basicAttack;

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
        player.GetComponentInChildren<CombatAnimationFunctions>().BasicAttack = true;
        GameObject abil = Instantiate(ability.animations[0], enemy.GetComponentInChildren<BoxCollider2D>().transform.position, Quaternion.identity, enemy.GetComponentInChildren<BoxCollider2D>().transform);
        
        abil.GetComponent<AbilityAnimationFunctions>().cast = player;

        if(abil.GetComponent<AbilityAnimationFunctions>().ability.aoe != true)
            abil.GetComponent<AbilityAnimationFunctions>().enemies[0] = enemy.GetComponent<EnemyStatus>();
        //deal damage

        enemyselects.SetActive(false);
    }
}
