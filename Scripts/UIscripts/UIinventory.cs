using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIinventory : MonoBehaviour {
	public InventoryObject inventory;
	public GameObject text;
	public GameObject inventoryPanel;

	void Awake() {
		List<GameObject> a = new List<GameObject> ();

		for( int i = 0; i < inventory.inventory.Count; ++i )
		{
			a.Add(Instantiate(text, inventoryPanel.transform));
			Text[] b = a[i].GetComponentsInChildren<Text>();

			b[0].text = inventory.inventory[i].item.itemName;
			b[1].text = inventory.inventory[i].amount.ToString();
		}
	}
}
