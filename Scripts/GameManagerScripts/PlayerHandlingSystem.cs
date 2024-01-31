using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandlingSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player;
        GameManagerScript gm;
        Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);

        gm = FindObjectOfType<GameManagerScript>();

        Player = gm.Player;

        Player.transform.position = pos;

        if(Player.GetComponent<PlayerController>().isActiveAndEnabled == false)
        {
            Player.GetComponent<PlayerController>().enabled = true;
        }

        foreach(Entrance entrance in FindObjectsOfType<Entrance>())
        {
            if(gm.GetComponent<LocationSystem>().buildingID == entrance.insideNum)
            {
                Player.transform.position = entrance.pos;
                break;
            }
        }
    }
}
