using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionScript : MonoBehaviour {

    public bool inRange = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            inRange = false;
        }
    }
}
