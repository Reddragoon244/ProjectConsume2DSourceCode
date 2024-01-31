using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionScript : MonoBehaviour {
    public GameObject character;
    public bool inRangeDialogue = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "NPC")
        {
            character = coll.gameObject;
            inRangeDialogue = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "NPC")
        {
            character = null;
            inRangeDialogue = false;
        }
    }
}
