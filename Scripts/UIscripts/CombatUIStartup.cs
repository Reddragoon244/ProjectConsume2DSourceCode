using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIStartup : MonoBehaviour
{
    void OnEnable()
    {
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GetComponentInChildren<Button>().gameObject);
    }
}
