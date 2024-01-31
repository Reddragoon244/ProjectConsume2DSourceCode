using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObjectTesting : MonoBehaviour {

    public InventoryItem inventoryItem;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {

        if(inventoryItem.item != null)
        {
            GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<InventoryManagement>().AddtoInventory(inventoryItem);
            Destroy(this.gameObject);
            Debug.Log("Mouse Click");
        }



    }

}
