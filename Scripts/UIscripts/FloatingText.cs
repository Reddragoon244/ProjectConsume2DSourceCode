using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    private float countTime;
    private float timeTilDestroy = 0.0f;
    // Update is called once per frame
    void Update()
    {
       timeTilDestroy += 1.0f / countTime * Time.deltaTime;
       if(timeTilDestroy >= 1.0f)
       {
         Destroy(this.gameObject);
       }
        
    }
}
