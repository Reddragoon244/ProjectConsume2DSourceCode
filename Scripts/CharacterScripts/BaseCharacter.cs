using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class BaseCharacter : ScriptableObject {

    public string characterName = "PHname";
    public Sprite characterSprite = null;
    public GameObject characterGameObject = null;
    public int level = 1;
}
