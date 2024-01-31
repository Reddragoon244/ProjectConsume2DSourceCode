using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBuildingGenerator : MonoBehaviour
{
    public GameObject[] insideBuilding;

    private GameManagerScript gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManagerScript>();

        if(insideBuilding.Length == 0)
        {
            Debug.Log("no inside building objects.");
        } else if(insideBuilding.Length >= gm.GetComponent<LocationSystem>().buildingID){
            Instantiate(insideBuilding[gm.GetComponent<LocationSystem>().buildingID], this.transform.position, Quaternion.identity);
        } else {
            Debug.Log("the inside building number and the building id do not match.");
        }
    }
}
