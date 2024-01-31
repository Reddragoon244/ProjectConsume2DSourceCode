using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllEnemySelectUI : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GetComponentInChildren<Button>().gameObject);
    }
}
