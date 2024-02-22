using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHighlighted : Selectable
{
    [SerializeField]
    private Text descriptionbox;

    [SerializeField]
    private Image spriteImage;

    public Item item;

    BaseEventData m_BaseEvent;

    private void Awake() {
        descriptionbox = GameObject.Find("DescriptionBox").GetComponent<Text>();
        spriteImage = GameObject.Find("ItemSpriteImage").GetComponent<Image>();
    }

    void Update() {
        if(IsHighlighted() == true) {
            descriptionbox.text = item.itemDescription;
            spriteImage.sprite = item.itemImage;
        }
    }
}
