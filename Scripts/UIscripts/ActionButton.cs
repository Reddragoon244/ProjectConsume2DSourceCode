using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public GameObject actionButton;
    public Text buttonText;
    public TriggerAreaScript playertrigger;
    public GameManagerScript gm;
    // Start is called before the first frame update
    void Start()
    {
        playertrigger = FindObjectOfType<PlayerController>().GetComponentInChildren<TriggerAreaScript>();
        gm = FindObjectOfType<GameManagerScript>();
        actionButton.SetActive(false);
        buttonText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(playertrigger.inRangeDialogue == true && gm.inDialogue == false) {
            actionButton.SetActive(true);
            buttonText.text = "Talk";
        } else if(playertrigger.inRangeChest == true && gm.inDialogue == false) {
            actionButton.SetActive(true);
            buttonText.text = "Open";
        } else if(playertrigger.inRangeDoor == true && gm.inDialogue == false) {
            actionButton.SetActive(true);
            buttonText.text = "Open";
        } else {
            actionButton.SetActive(false);
            buttonText.text = "";
        }
    }
}
