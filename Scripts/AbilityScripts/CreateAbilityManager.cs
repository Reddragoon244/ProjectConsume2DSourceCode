using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAbilityManager : MonoBehaviour {

    public InventoryManagement playerInventory;
    public AbilityManagement playerAbilityLibrary;

    public SpellBookUI spellbook;
    public BaseAbility LeftAbility;
    public BaseAbility RightAbility;


    int j = 0;

    void Start()
    {
        playerInventory = FindObjectOfType<InventoryManagement>();
        playerAbilityLibrary = FindObjectOfType<AbilityManagement>();
    }

    public bool CanCreateAbility(InventoryItem[] items, BaseAbility ability)
    {
        if (items.Length != 0)
        { 
            foreach (InventoryItem i in items)
            {
                if (i != null)
                {
                    if (playerInventory.SearchforItem(i))
                    {
                        if (playerInventory.inventory.inventory.Find(k => k.item.itemID == i.item.itemID).amount >= i.amount)
                        {
                            j++;
                        }
                    }
                }
            }
        }

        if (j == items.Length)
        {
            j = 0;
            return true;
        }
        else {
            j = 0;
            return false;
        }
            
    }

    public void createLeftAbility()
    {
        LeftAbility = spellbook.leftSpell;

        foreach(InventoryItem i in LeftAbility.craftingMaterialsNeeded)
        {
            if (playerInventory.SearchforItem(i)) {
                playerInventory.RemoveByAmountInventory(i, i.amount);
            }
        }
        playerAbilityLibrary.library.library.Add(LeftAbility);
    }

    public void createRightAbility()
    {
        RightAbility = spellbook.rightSpell;

        foreach (InventoryItem i in RightAbility.craftingMaterialsNeeded)
        {
            if (playerInventory.SearchforItem(i))
            {
                playerInventory.RemoveByAmountInventory(i, i.amount);
            }
        }
        playerAbilityLibrary.library.library.Add(RightAbility);
    }
}
