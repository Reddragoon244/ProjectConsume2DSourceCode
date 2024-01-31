using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIInventoryDesc : MonoBehaviour, ISelectHandler , IPointerEnterHandler
{
    public InventoryObject inventory;
    public string ItemName;
    public Text itemDesc;
    
    // When highlighted with mouse.
     public void OnPointerEnter(PointerEventData eventData)
     {
         // Do something.
         Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
     }
     // When selected.
     public void OnSelect(BaseEventData eventData)
     {
         // Do something.
         Debug.Log("<color=red>Event:</color> Completed selection.");
     }
    
}
