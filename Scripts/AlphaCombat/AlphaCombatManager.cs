using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaCombatManager : MonoBehaviour {
    public List<GameObject> enemylist = new List<GameObject>();
    public List<GameObject> combatcharacterlist = new List<GameObject>();
	public List<GameObject> orderedMembers = new List<GameObject>();
	public List<GameObject> members = new List<GameObject>();
    public List<GameObject> positions = new List<GameObject>();

    void Start() {
        int i = 0;
        int location = FindObjectOfType<LocationSystem>().enemyspawnlocation;
        combatcharacterlist = new List<GameObject>();
        foreach (GameObject enemy in enemylist)
        {
            if(enemy.GetComponent<EnemyStatus>().spawnlocation == location)
            {
                combatcharacterlist.Add(enemy);
            }
        }

        foreach(GameObject combatenemy in combatcharacterlist.ToArray())
        {
            combatcharacterlist[i] = Instantiate(combatenemy, positions[i].transform, false);
            i++;
        }
    }

    void Update() {
		for(int i = 0; i < members.Count; i++)
		{
			if(members[i] != null){
				if(members[i].GetComponentInChildren<AlphaPlayerCombat>().playerActive == true)
				{
					if(!orderedMembers.Contains(members[i]))
						orderedMembers.Add(members[i]);
				} else 
				{
					if(orderedMembers.Contains(members[i]))
						orderedMembers.Remove(members[i]);
				}
			}
		}
	}

	public GameObject randomPlayer() {
		int newcount = 0;
		for(int j = 0; j < members.Count; j++)
		{
			if(members[j] != null)
			{
				newcount++;
			}
		}
		
		int rand = (int)Random.Range(1.0f, newcount);
		int i = 1;

		foreach(GameObject character in members) {
			if(rand == i) {
				return character;
			}
		}

		return combatcharacterlist[0];
	}

	public GameObject randomCharacter() {
		int rand = (int)Random.Range(1.0f, combatcharacterlist.Count);
		int i = 1;

		foreach(GameObject character in combatcharacterlist) {
			if(rand == i) {
				return character;
			}
		}

		return combatcharacterlist[0];
	}
}
