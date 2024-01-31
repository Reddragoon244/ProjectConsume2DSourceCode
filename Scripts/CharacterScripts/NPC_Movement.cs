using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour {

	public Animator anim;
    public GameManagerScript gm;
    public GameObject[] triggerareas = new GameObject[4]; 
    public bool Roam, Static;
	public float moveSpeed = 0.05f;
    private Vector2 direction;
	private float idleX;
	private float idleY;
	private float hoz;
	private float ver;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator>();
        gm = FindObjectOfType<GameManagerScript>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        if(gm.inDialogue == false)
        {
            if(Roam == true)
                AI();
            else
            {
                if(Static == true)
                {
                    anim.speed = 1.0f;
                }
            }
        } 
        else
        {
            checkcolliders();

            if(Static == true)
            {
                anim.speed = 0.0f;
            }

            hoz = 0.0f;
            ver = 0.0f;
            idleX = direction.x;
            idleY = direction.y;

        }
        
        if(Static == false)
            Animation();
    }

    void Animation()
    {
        anim.SetFloat("VelX", hoz);
        anim.SetFloat("VelY", ver);

        if (hoz > 0.5f && ver == 0.0f)
        {

            anim.SetFloat("IdleX", hoz);
            anim.SetFloat("IdleY", ver);
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector2.right * moveSpeed);
        }
        else if (hoz < -0.5f && ver == 0.0f)
        {

            anim.SetFloat("IdleX", hoz);
            anim.SetFloat("IdleY", ver);
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector2.left * moveSpeed);
        }
        else if (ver > 0.5f && hoz == 0.0f)
        {

            anim.SetFloat("IdleX", hoz);
            anim.SetFloat("IdleY", ver);
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector2.up * moveSpeed);
        }
        else if (ver < -0.5f && hoz == 0.0f)
        {

            anim.SetFloat("IdleX", hoz);
            anim.SetFloat("IdleY", ver);
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector2.down * moveSpeed);
        }
        else
        {

            anim.SetFloat("IdleX", idleX);
            anim.SetFloat("IdleY", idleY);
            anim.SetBool("Movement", false);

        }
    }
    void AI()
    {
        //Closest I have to AI NPC Movement//
        if (Time.time % 2 > 1.9f)
            hoz = Random.Range(-1.0f, 1.0f);

        if (Time.time % 2 > 1.9f)
            ver = Random.Range(-1.0f, 1.0f);

        if (Time.time % 4 > 3.9f)
            ver = 0.0f;

        if (Time.time % 5 > 4.9f)
            hoz = 0.0f;
    }

    void checkcolliders() 
    {
        direction = new Vector2 (0.0f, 0.0f);

        foreach(GameObject trigger in triggerareas) {
            if(trigger.GetComponent<TriggerAreaScript>().inRangeDialogue == true)
            {
                if(trigger.name == "TriggerAreaTop")
                {
                    direction = new Vector2 (0.0f, 1.0f);
                } else if(trigger.name == "TriggerAreaLeft")
                {
                    direction = new Vector2 (-1.0f, 0.0f);
                } else if(trigger.name == "TriggerAreaRight")
                {
                    direction = new Vector2 (1.0f, 0.0f);
                } else if(trigger.name == "TriggerAreaBottom")
                {
                    direction = new Vector2 (0.0f, -1.0f);
                }

            }
        }
    }

}
