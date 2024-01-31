using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaLowHealth : MonoBehaviour
{
    public float blinkTime;
    private float blinkStart = 0.0f;
    private float temperature = 1.0f;
    private bool endTime = false, procOnce = false;
    private CombatCharacterStatus character;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<CombatCharacterStatus>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(character.hpCurrent <= (int)(character.hpCap * 0.2f))
        {
            procOnce = false;
            if(endTime == true)
            {
                blinkStart -= 1.0f / blinkTime * Time.deltaTime;
                temperature -= temperature +  0.05f;
                spriteRenderer.color = new Color (1.0f,temperature,temperature);
                
                if(blinkStart <= 0.0f)
                {
                    spriteRenderer.color = new Color (1.0f,1.0f,1.0f);
                    endTime = false;
                }
                    
            } else if(endTime == false)
            {
                blinkStart += 1.0f / blinkTime * Time.deltaTime;
                temperature += temperature + 0.05f;
                spriteRenderer.color = new Color (1.0f,temperature,temperature);

                if(blinkStart >= 1.0f)
                {
                    spriteRenderer.color = new Color (1.0f,1.0f,1.0f);
                    endTime = true;
                }
            }
        } else {
            if(temperature != 1.0f && procOnce == false)
            {
                spriteRenderer.color = new Color (1.0f,1.0f,1.0f);
                procOnce = true;
            }

                
        }
    }
}
