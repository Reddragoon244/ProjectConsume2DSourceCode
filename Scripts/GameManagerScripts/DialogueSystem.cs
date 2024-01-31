using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour {
    public DialogueScript dialogue;
    public GameObject DialogueBox;
    public SlowDialogueText DialogueText;
    
    public static DialogueSystem instance;
    
    private GameManagerScript gm;

    // Use this for initialization
    void Start () {
        if(instance == null)
            instance = this;
        
        gm = GetComponent<GameManagerScript>();

        if(DialogueBox != null)
        {
            if (DialogueBox.activeInHierarchy)
                DialogueBox.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.inDialogue == true && dialogue != null)
            DialogueText.dialogue = dialogue;
    }
}
