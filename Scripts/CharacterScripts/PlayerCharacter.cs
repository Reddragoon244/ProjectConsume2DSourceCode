using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class PlayerCharacter : CombatCharacter {

    public int currentExp;
    public int nextlvlExp = 100;

    public EquipmentItem helm;
    public EquipmentItem chest;
    public EquipmentItem gloves;
    public EquipmentItem weapon;
    public EquipmentItem accessory1;
    public EquipmentItem accessory2;

}
