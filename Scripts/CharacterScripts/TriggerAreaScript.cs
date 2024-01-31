using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaScript : MonoBehaviour
{
    public GameObject character;
    public bool isPlayer = false;
    public bool inRangeDialogue = false;
    public bool inRangeDoor = false;
    public bool inRangeChest = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.GetComponent<TriggerAreaScript>())
        {
            if(isPlayer == true)
            {
                if (coll.GetComponentInParent<NPC_Movement>().tag == "NPC")
                {
                    character = coll.GetComponentInParent<NPC_Movement>().gameObject;
                    inRangeDialogue = true;
                }
            } 
            else if(isPlayer == false) 
            {
                if (coll.GetComponentInParent<PlayerController>().tag == "Player")
                {
                    character = coll.GetComponentInParent<PlayerController>().gameObject;
                    inRangeDialogue = true;
                }
            }
        } else if (coll.tag == "Treasure Chest")//need to test
        {
            inRangeChest = true;
        } else if (coll.tag == "EntranceAndExit")//need to test
        {
            inRangeDoor = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.GetComponent<TriggerAreaScript>())
        {
            if(isPlayer == true)
            {
                if (coll.GetComponentInParent<NPC_Movement>().tag == "NPC")
                {
                    character = null;
                    inRangeDialogue = false;
                } 
            }
            else if(isPlayer == false) 
            {
                if (coll.GetComponentInParent<PlayerController>().tag == "Player")
                {
                    character = null;
                    inRangeDialogue = false;
                }
            }
        } else if (coll.tag == "Treasure Chest")//need to test
        {
            inRangeChest = false;
        } else if (coll.tag == "EntranceAndExit")//need to test
        {
            inRangeDoor = false;
        }
    }
}
