using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaEnemyCombat : MonoBehaviour {
	public float currentTime, finishedTime;
	public bool enemyActive = false;
	public EnemyStatus enemy;
	public GameObject target;

	// Use this for initialization
	void Start () {
		currentTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTime < finishedTime) {
			currentTime = currentTime + Time.deltaTime;
		} else {
			enemyActive = true;
			//enemy attack
			enemyBasicAction(enemyTarget());
			afterTurn();
		}
	}
	GameObject enemyTarget() {
		if(enemy.findStatus(CombatCharacter.status.Confused)) {
			target = FindObjectOfType<AlphaCombatManager>().randomCharacter();
			return target;
		} else {
			//this needs to change
			target = FindObjectOfType<AlphaCombatManager>().randomPlayer();
			return target;
		}
	}
	void enemyBasicAction(GameObject target) {
		GameObject abil = Instantiate(GetComponent<EnemyStatus>().basicAbility.animations[0], target.GetComponentInChildren<BoxCollider2D>().transform.position, Quaternion.identity, target.GetComponentInChildren<BoxCollider2D>().transform);
		abil.GetComponent<AbilityAnimationFunctions>().cast = enemy;

		if(abil.GetComponent<AbilityAnimationFunctions>().ability.aoe != true)
            abil.GetComponent<AbilityAnimationFunctions>().enemies[0] = target.GetComponent<PlayerStatus>();

		FindObjectOfType<AlphaCombatUIController>().combattextstring(enemy.character.characterName + " deals " + target.GetComponent<CombatCharacterStatus>().currentDamage + " to " + target.GetComponent<CombatCharacterStatus>().character.characterName + " ");
	}
	public void afterTurn() {
		enemyActive = false;
		currentTime = 0.0f;
	}
}
