using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour {

    public EnemyStatus[] enemies;
    public int MAX_ENEMEIES = 8;

    void Start()
    {
        enemies = new EnemyStatus[MAX_ENEMEIES];
    }

}
