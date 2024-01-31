using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AbilityButton : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public PlayerStatus player;
    public int abilityNumber;
    private BaseAbility ability;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<CombatMenu>().member;
        ability = player.GetComponent<ActiveAbilities>().activeAbilities[abilityNumber-1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AbilityAction()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
    }
    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
    }
}
