using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySystem : MonoBehaviour
{
    public GameObject[] partymembers = new GameObject[8];
    public GameObject PHmember = null;
    // Start is called before the first frame update
    void Start()
    {
        PHmember = null;   
    }

    public void AddPartyMember(GameObject Member)
    {
        for(int i = 0; i < 8; i++)
        {
            if(partymembers[i] == null)
            {
                partymembers[i] = Member;
                break;
            }
        }
    }

    public void RemovePartyMember(GameObject Member)
    {
        for(int i = 0; i < 8; i++)
        {
            if(partymembers[i] == Member)
            {
                partymembers[i] = null;
                StorePHMember(partymembers[i]);
                break;
            }
        }
    }

    public void StorePHMember(GameObject member)
    {
        PHmember = member;
    }
}
