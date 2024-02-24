using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTextUI : MonoBehaviour
{
    public GameObject enemy;
    public GameObject text;
    public int Number;
    public bool member;
    // Start is called before the first frame update
    void Start()
    {
        if(member == false)
        {
            if(FindObjectOfType<AlphaCombatManager>().combatcharacterlist.Count < Number)
            {
                this.gameObject.SetActive(false);
            }

            if (enemy.GetComponentInChildren<EnemyStatus>())
            {
                enemy = enemy.GetComponentInChildren<EnemyStatus>().gameObject;
            }
        } else
        {
            if(FindObjectOfType<AlphaCombatManager>().members.Count < Number)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy == null)
            this.gameObject.SetActive(false);
        
        if(member == false)
        {
            if(enemy.GetComponent<EnemyStatus>().DamageTaken != 0)
            {
                GameObject floatText = Instantiate(text, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                floatText.GetComponent<Text>().text = enemy.GetComponent<EnemyStatus>().DamageTaken.ToString();
                floatText.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 3.0f, 0.0f);
                enemy.GetComponent<EnemyStatus>().DamageTaken = 0;
            }

            for(int i = 0; i < enemy.GetComponent<EnemyStatus>().status.Length; i++)
            {
                if(enemy.GetComponent<EnemyStatus>().status[i] == CombatCharacter.status.Dead)
                {
                    this.gameObject.SetActive(false);
                }
            }
        } else
        {
            if(FindObjectOfType<AlphaCombatManager>().members[Number-1].GetComponent<PlayerStatus>().DamageTaken != 0)
            {
                GameObject floatText = Instantiate(text, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                floatText.GetComponent<Text>().text = FindObjectOfType<AlphaCombatManager>().members[Number-1].GetComponent<PlayerStatus>().DamageTaken.ToString();
                floatText.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 3.0f, 0.0f);
                FindObjectOfType<AlphaCombatManager>().members[Number-1].GetComponent<PlayerStatus>().DamageTaken = 0;
            }

            for(int i = 0; i < FindObjectOfType<AlphaCombatManager>().members[Number-1].GetComponent<PlayerStatus>().status.Length; i++)
            {
                if(FindObjectOfType<AlphaCombatManager>().members[Number-1].GetComponent<PlayerStatus>().status[i] == CombatCharacter.status.Dead)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
