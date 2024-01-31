using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public GameObject Player;
    public bool inDialogue = false;
    public bool inMenu = false;
    public bool inCombat = false; 
    public bool in2dSpace = false;
    public bool in3dSpace = false;
    
    public static GameManagerScript instance;
    
    private CombatSystem CombatSystem;
    private DialogueSystem DialogueSystem;
    private ProgressionSystem ProgressionSystem;
    private MenuSystem MenuSystem;

    void Awake() {
        if(instance == null)
            instance = this;
        
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if(instance == null)
            instance = this;
        
        CombatSystem = GetComponent<CombatSystem>();
        DialogueSystem = GetComponent<DialogueSystem>();
        ProgressionSystem = GetComponent<ProgressionSystem>();
        MenuSystem = GetComponent<MenuSystem>();
    }

    public void DialogueAction() 
    {
        /*Dialogue Action in use*/    
        if(inDialogue == false)
        {
            DialogueSystem.dialogue = null;
            DialogueSystem.DialogueBox.SetActive(false);
        }
        /*Dailogue Action not in use*/
    }
    public void DialogueAction(DialogueScript dialogue) 
    {
        /*Dialogue Action in use*/    
        if(inDialogue == true) 
        {
            DialogueSystem.dialogue = dialogue;
            DialogueSystem.DialogueBox.SetActive(true);
        }
        /*Dailogue Action not in use*/
    }

    public void CombatAction()
    {
        /*Entering Combat*/
        if (inCombat == false)
        {
            inCombat = true;

            in3dSpace = true;
            in2dSpace = false;
        }
        else
        {
            inCombat = false;

            in2dSpace = true;
            in3dSpace = false;
        }
        /*Exiting Combat*/
    }

    public void MenuAction()
    {
        /*Activate Menus*/
        if (inMenu == false)
        {
            inMenu = true;
        }
        else
        {
            inMenu = false;
        }
        /*Pause Game*/
    }

    public void ProgressionAction()
    {
        /*Progession System*/
    }
}
