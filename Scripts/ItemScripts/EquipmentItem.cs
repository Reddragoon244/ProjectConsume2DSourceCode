using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class EquipmentItem : Item {

    public enum type {Helm, Chest, Gloves, Weapon, Accessory};

	public int hp;
	public int strength;
	public int intelligence;
    public int defense;
	public int speed;
	public string specialText;
	public int Critical;
	public int Haste;

    public type equipmentType;

}
