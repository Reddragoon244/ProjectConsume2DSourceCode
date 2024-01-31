using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaEndCombatScript : MonoBehaviour
{
    public GameObject VictoryMenu;
    public GameObject CombatUI;
    public int Allexp = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(VictoryMenu.activeSelf)
            VictoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!FindObjectOfType<EnemyStatus>())
        {
            Debug.Log("battle ends");
            CombatUI.SetActive(false);
            VictoryMenu.SetActive(true);
        }
    }
}
