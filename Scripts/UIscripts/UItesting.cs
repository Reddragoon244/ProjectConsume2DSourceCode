using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItesting : MonoBehaviour {

    public RawImage image;

    public InventoryObject inventory;
    public InventoryItem invItem;

	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<InventoryManagement>().inventory;
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(inventory.inventory.Count);
        foreach (InventoryItem item in inventory.inventory)
        {
            image.texture = item.item.itemImage.texture;
            invItem = item;
        }

        if (inventory.inventory.Count == 0)
        {
            image.texture = null;
            invItem = null;
        }
        

	}

    public void UseItem(InventoryItem item)
    {
        GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<InventoryManagement>().RemovefromInventory(item);
    }
}
