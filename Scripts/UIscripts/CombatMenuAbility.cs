using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuAbility : MonoBehaviour
{
    public GameObject playermenu, AbilityMenu, combatmenu;
    public BaseAbility ability;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbilityButton()
    {
        combatmenu.SetActive(false);
        AbilityMenu.SetActive(true);
    }
}
