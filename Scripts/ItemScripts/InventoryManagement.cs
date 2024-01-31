using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour {

    public InventoryObject defaultInventory;
    public InventoryObject inventory;
    
    public static InventoryManagement instance;

	// Use this for initialization
	void Start () {
        if(instance == null)
            instance = this;
        
        if(inventory == null)
            inventory = defaultInventory;
	}

    public void AddtoInventory(InventoryItem item)
    {

        if(inventory.inventory.Count == 0)
            inventory.inventory.Add(item);
        else if (SearchforItem(item))
        {
            inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID).amount = inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID).amount + item.amount;
        } else { 
            inventory.inventory.Add(item);
        }

    }

    public void RemovefromInventory(InventoryItem item)
    {
        if (SearchforItem(item))
        {
            inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID).amount = inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID).amount - 1;
            if (inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID).amount == 0)
            {
                inventory.inventory.Remove(inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID));
            }
        }
    }

    public void RemoveByAmountInventory(InventoryItem item, int removingAmount)
    {
        if (SearchforItem(item))
        {
            inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID).amount = inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID).amount - removingAmount;
            if (inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID).amount == 0)
            {
                inventory.inventory.Remove(inventory.inventory.Find(invItem => invItem.item.itemID == item.item.itemID));
            }
        }
    }

    public bool SearchforItem(InventoryItem inventoryItem)
    {
        foreach (InventoryItem item in inventory.inventory)
        {
            if (item != null && inventoryItem != null)
            {
                if (inventoryItem.item.itemID == item.item.itemID)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
