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
    public GameObject playermenu, enemyselects, abilitymenu;
    public Image abilityImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(ability == null)
        {
            abilityImage.sprite = playermenu.GetComponent<CombatMenu>().member.GetComponent<ActiveAbilities>().activeAbilities[abilityNumber].UIicon;
            ability = playermenu.GetComponent<CombatMenu>().member.GetComponent<ActiveAbilities>().activeAbilities[abilityNumber];
        }
    }

    public void AbilityAction()
    {
        //attack
        enemyselects.SetActive(true);
        playermenu.SetActive(false);
        abilitymenu.SetActive(false);
    }
}
