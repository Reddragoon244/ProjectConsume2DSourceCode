using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu]
public class JobScript : ScriptableObject {
	public enum jobName {
	Pyromancy, // powrer of fire
	 Fulgurmancy, // power of lightnening
	  Cryomancy, // power of ice
	   Geomancy, // power of earth
	    Magi, // power of arcane
		 Priest, // power of holy
		  Warlock, // power of shadow
		   Summoner, // power of monsters
		    Bishop, // power of light
			 Squire, // basic
			  Militia, // another basic
			   Archer, 
			    Fighter,
				 Swordsman, // power of swords
				  Paladin, // power of swords and holy and light
				   Samurai, // power of swords and lightnening
				    Phoenix, // power of swords and fire
					 Lich, // power of death
					  Necromancer // power of death and shadow and swords
	};
	public jobName jobname;
	public bool unlocked = false;
	public List <BaseAbility> abilityList = new List<BaseAbility> ();
}
