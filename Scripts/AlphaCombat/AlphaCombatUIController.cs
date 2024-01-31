using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaCombatUIController : MonoBehaviour {
	public Text combatText;
	public Image fillbar;
	public AlphaPlayerCombat playercombat;
	public AlphaCombatManager combatManager;
	[SerializeField]
	private string combatString = "";
	void Update() {
		if(combatManager.orderedMembers.Count > 0)
		{
			foreach(GameObject member in combatManager.orderedMembers)
			{
				//should control all the UI
			}
		}

		if(playercombat.playerActive == true)
		{	
			fillbar.gameObject.SetActive(false);
		} else {
			fillbar.gameObject.SetActive(true);
		}
	}
	public void combattextstring(string text) {
		combatText.text = text;
		combatString += text + "\n";
	}
}
