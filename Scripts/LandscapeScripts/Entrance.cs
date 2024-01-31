using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public int insideNum;
    public Vector3 pos;

    void Start() {
        pos = this.transform.position;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "TriggerArea")
        {
            FindObjectOfType<LocationSystem>().returnPos = coll.GetComponentInParent<Transform>().position;
            FindObjectOfType<LocationSystem>().buildingID = insideNum;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.name == "TriggerArea")
        {
            FindObjectOfType<LocationSystem>().buildingID = 0;
        }
    }
}
