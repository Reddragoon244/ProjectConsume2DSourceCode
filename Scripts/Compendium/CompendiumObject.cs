using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class CompendiumObject : ScriptableObject
{
    public List<CompendiumItem> compendium = new();
}

