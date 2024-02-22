using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class CompendiumItem : ScriptableObject
{
    public string CompObjName = null;
    public Sprite CompObjImage = null;
    public Sprite CompObjAltImage = null;
    public GameObject gameObject = null;
    public GameObject gameObjectAlt = null;
	public string CompObjDescription;
    public int CompObjID;
    public string CompObjLocation;
    public bool CompObjHaveSeen = false;
    public int CompObjdefeated = 0;
    public int CompObjseen = 0;
    public int CompObjobtain = 0;
}
