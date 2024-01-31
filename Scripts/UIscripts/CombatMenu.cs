using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : MonoBehaviour
{
    public PlayerStatus member;
    public MemberSelect memSelect;
    public int memberNumber;

    void OnEnable()
    {
        memberNumber = memSelect.MemberNumber;
        member = FindObjectOfType<AlphaCombatManager>().members[memberNumber-1].GetComponent<PlayerStatus>();
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GetComponentInChildren<Button>().gameObject);
    }
}
