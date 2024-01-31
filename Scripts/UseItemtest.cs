using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemtest : MonoBehaviour {

    public InventoryManagement inventory;

    // Use this for initialization
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<InventoryManagement>();
    }

    void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<InventoryManagement>();
    }

    public void UseItem()
    {
        inventory.RemovefromInventory(this.GetComponentInParent<UItesting>().invItem);
    }
}
