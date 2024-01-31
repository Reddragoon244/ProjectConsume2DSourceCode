using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour {
    
    public BaseCharacter character;
    public StoryScript story;
    public string[] dialogueArray = new string[10];
    public string Name;
    public string dialogue = "";
    public int storyProgression = 0;
    
    [SerializeField]
    private string charName = "";

	// Use this for initialization
	void Start () {
        story = FindObjectOfType<StoryScript>();
        Name = charName = character.characterName;

        if(dialogue == "" || dialogue == null)
        {
            dialogue = "this is error";
        } else
        {
            //dialogue = dialogue.Substring(dialogue.IndexOf(charName) + charName.Length);
            //dialogue = dialogue.Substring(0, dialogue.IndexOf('#'));
            dialogueChange();
        }
    }

    void Update()
    {
        dialogueChange();
    }

    /*Used to change dialogue from story progression*/
    void dialogueChange()
    {
        switch (storyProgression)
        {
            case 9:
                dialogue = dialogueArray[9];
                break;
            case 8:
                dialogue = dialogueArray[8];
                break;
            case 7:
                dialogue = dialogueArray[7];
                break;
            case 6:
                dialogue = dialogueArray[6];
                break;
            case 5:
                dialogue = dialogueArray[5];
                break;
            case 4:
                dialogue = dialogueArray[4];
                break;
            case 3:
                dialogue = dialogueArray[3];
                break;
            case 2:
                dialogue = dialogueArray[2];
                break;
            case 1:
                dialogue = dialogueArray[1];
                break;
            case 0:
                dialogue = dialogueArray[0];
                break;

        }
    }
}
