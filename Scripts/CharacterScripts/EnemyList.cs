using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class EnemyList : ScriptableObject
{
    public List<GameObject> database = new List<GameObject>();
}
