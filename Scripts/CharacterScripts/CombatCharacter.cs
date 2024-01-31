using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class CombatCharacter : BaseCharacter {

    public enum status { None, Burned, Chilled, Frozen, Cursed, Confused, Protected, Diseased, Shocked, Nullified, Silenced, Stunned, Dead };

    public int healthpointCurrent = 1;
    public int healthpointCap = 1;
    public int manapointCurrent = 0;
    public int manapointCap = 0;
    public int defensepoints = 0;
    public int strpoints = 0;
    public int intpoints = 0;
    public float criticalratio = 1.0f;
    public float hasteratio = 1.0f;
    public int GainEXP = 100;
    public int lootSize = 1;

    /*Loot Table*/
    public InventoryItem[] loottable;
}
