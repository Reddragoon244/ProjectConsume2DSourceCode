using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    public PlayerStatus player;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = FindAnyObjectByType<PlayerStatus>();

        text.GetComponent<TextMeshProUGUI>().text = player.playercharacter.characterName + "\n" + player.hpCurrent + "/" + player.hpCap + "\n" + player.manaCurrent + "/" + player.manaCap;
    }
}
