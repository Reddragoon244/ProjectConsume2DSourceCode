using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowDialogueText : MonoBehaviour {
    public DialogueScript dialogue;
    public Text characterName;
    public Text dialogueText;
    public Button continueButton;
    public float delayText;
    public bool dialogueDone = false;
    private Coroutine slowCoro = null;

    void OnEnable()
    {
        dialogue = FindObjectOfType<PlayerController>().GetComponentInChildren<TriggerAreaScript>().character.GetComponent<DialogueScript>();
        dialogueDone = false;
        characterName.text = dialogue.Name;
        slowCoro = StartCoroutine(TypeText());
    }

    void OnDisable()
    {
        dialogue = null;
        characterName.text = "";
        dialogueText.text = "";
    }

    IEnumerator TypeText()
    {
        for(int i = 0; i <= dialogue.dialogue.Length; i++) 
        {
            dialogueText.text = dialogue.dialogue.Substring(0,i);
            yield return new WaitForSeconds(delayText);
        }
            
        dialogueDone = true;
    }

    public void finishtext()
    {
        Debug.Log("finish text 1"); 
        StopCoroutine(slowCoro);
        dialogueText.text = dialogue.dialogue;
        dialogueDone = true;
    }
}
