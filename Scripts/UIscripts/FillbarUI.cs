using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillbarUI : MonoBehaviour
{
    public int MemeberNumber;
    public GameObject playerselect;
    private Image fillbar;
    private AlphaPlayerCombat playercombat;
    void OnEnable() {
        playercombat = FindObjectOfType<AlphaCombatManager>().members[MemeberNumber-1].GetComponentInChildren<AlphaPlayerCombat>();
        playercombat.GetComponent<CombatAnimationFunctions>().KneelLight = true;
        fillbar = GetComponent<Image>();
        fillbar.fillAmount = 0.0f;
    }
    // Update is called once per frame
    void Update() {
        fillbar.fillAmount += 1.0f / playercombat.finishedTime * Time.deltaTime;
        if(fillbar.fillAmount >= 1.0f)
        {
            fillbar.gameObject.SetActive(false);
        }
    }
    void OnDisable() {
        if(playercombat)
        {
            playercombat.GetComponent<CombatAnimationFunctions>().KneelLight = false;
            playercombat.GetComponent<CombatAnimationFunctions>().Idle = true;
        }
        playerselect.SetActive(true);
        
    }
}
