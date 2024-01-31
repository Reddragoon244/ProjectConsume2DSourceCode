using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseSystem : MonoBehaviour
{
    public GameObject[] insideGameObject;
    // Start is called before the first frame update
    void Start()
    {
        if(insideGameObject.Length == 0)
        {
            Debug.Log("add inside GameObject");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
