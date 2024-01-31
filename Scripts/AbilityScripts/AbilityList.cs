using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class AbilityList : ScriptableObject {

    public List<BaseAbility> library = new List<BaseAbility>();
}
