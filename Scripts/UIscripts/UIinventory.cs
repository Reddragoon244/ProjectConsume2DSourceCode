using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
			UIHighlighted c = a[i].GetComponent<UIHighlighted>();
			Text[] b = a[i].GetComponentsInChildren<Text>();

			c.item = inventory.inventory[i].item;
			b[0].text = inventory.inventory[i].item.itemName;
			b[1].text = inventory.inventory[i].amount.ToString();
		}
	}
}
