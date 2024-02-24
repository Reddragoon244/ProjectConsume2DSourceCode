using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AbilityButton : MonoBehaviour
{
    public int abilityNumber;
    private BaseAbility ability;
    public GameObject playermenu, enemyselects, combatmenu, abilitymenu;
    public Image abilityImage;
    // Start is called before the first frame update
    void Start()
    {
        //no ability dont show
        if(playermenu.GetComponent<CombatMenu>().member.GetComponent<ActiveAbilities>().activeAbilities[abilityNumber] == null)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ability == null)
        {
            if(playermenu.GetComponent<CombatMenu>().member.GetComponent<ActiveAbilities>().activeAbilities[abilityNumber] != null) {
                abilityImage.sprite = playermenu.GetComponent<CombatMenu>().member.GetComponent<ActiveAbilities>().activeAbilities[abilityNumber].UIicon;
                ability = playermenu.GetComponent<CombatMenu>().member.GetComponent<ActiveAbilities>().activeAbilities[abilityNumber];
            }
        }
    }

    public void AbilityAction()
    {
        //attack
        playermenu.GetComponent<CombatMenuAbility>().ability = ability;
        if(ability.manaUse <= playermenu.GetComponent<CombatMenu>().member.GetComponent<CombatCharacterStatus>().manaCurrent) {
            enemyselects.SetActive(true);
            combatmenu.SetActive(false);
            abilitymenu.SetActive(false);
        } else {
            //this is where we will have something telling us we dont have enough mana
            combatmenu.SetActive(true);
            abilitymenu.SetActive(false);
        }
        
    }
}
