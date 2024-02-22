using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuAbility : MonoBehaviour
{
    public GameObject playermenu;
    public GameObject AbilityMenu;
    public GameObject[] combatmenu = new GameObject[4];
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
        combatmenu[0].gameObject.SetActive(false);
        combatmenu[1].gameObject.SetActive(false);
        combatmenu[2].gameObject.SetActive(false);
        combatmenu[3].gameObject.SetActive(false);
        AbilityMenu.gameObject.SetActive(true);
    }
}
