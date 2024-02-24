using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuBasicAttack : MonoBehaviour
{
    public GameObject playermenu, enemyselects, combatmenu;
    public BaseAbility basicAttack = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(basicAttack == null)
        basicAttack = playermenu.GetComponent<CombatMenu>().member.GetComponent<ActiveAbilities>().baseAttack;
    }

    void OnDisable()
    {

    }

    public void AttackButton() {
      //attack
      enemyselects.SetActive(true);
      combatmenu.SetActive(false);
    }
}
