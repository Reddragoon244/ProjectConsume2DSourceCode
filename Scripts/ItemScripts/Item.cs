using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[System.Serializable, CreateAssetMenu]
public class Item : ScriptableObject
{
	public string itemName = null;
    public Sprite itemImage = null;
    public GameObject gameObject = null;
	public string itemDescription;
	public bool itemUnique;
    public bool isStackable = false;
	public int buyPrice;
	public int sellPrice;
    public int itemID;

}
