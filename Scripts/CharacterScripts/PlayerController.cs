using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 0.05f;
    private Animator anim;
    private GameManagerScript gm;
    private TriggerAreaScript playertrigger;
    private List<float> dist;
    private float idleX;
    private float idleY;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    
	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManagerScript>();
        anim = GetComponentInChildren<Animator>();
        playertrigger = GetComponentInChildren<TriggerAreaScript>();

        if(gm.GetComponent<SceneManagementSystem>().CheckScene() == "AlphaGame")
        {
            this.transform.position = gm.GetComponent<LocationSystem>().returnPos;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Action();

        if (gm.inDialogue == false && gm.inMenu == false)
        {
            if(gm.in2dSpace == true && gm.in3dSpace == false)
                Movement2D();
            if (gm.in3dSpace == true && gm.in2dSpace == false)
                Movement3D();
        } 
        else if (gm.inDialogue == true || gm.inMenu == true)
        {
            anim.SetBool("Movement", false);
        }
    }

    void Action() {
        if(Input.GetButtonDown("Fire1"))//Action Button AKA:A
        {
            if(gm.inMenu == false) {
                //Dialogue
                if(playertrigger.inRangeDialogue == true) 
                {
                    if(gm.inDialogue == true) 
                    {
                        if(FindObjectOfType<DialogueSystem>().DialogueText.dialogueDone == false)
                            FindObjectOfType<DialogueSystem>().DialogueText.finishtext();
                        else if(FindObjectOfType<DialogueSystem>().DialogueText.dialogueDone == true)
                        {
                            gm.inDialogue = false;
                            gm.DialogueAction();
                        }
                    } 
                    else if(gm.inDialogue == false) 
                    {
                        gm.inDialogue = true;
                        gm.DialogueAction(playertrigger.character.GetComponentInChildren<DialogueScript>());
                    }
                } else if(playertrigger.inRangeDoor == true) 
                {
                    if(gm.GetComponent<SceneManagementSystem>().CheckScene() == "InsideBuilding")
                    {
                        playertrigger.inRangeChest = false;
                        playertrigger.inRangeDialogue = false;
                        playertrigger.inRangeDoor = false;
                        gm.GetComponent<SceneManagementSystem>().SceneChange("AlphaGame");
                        gm.playeroutside = true;
                    } else if(gm.GetComponent<SceneManagementSystem>().CheckScene() == "AlphaGame")
                    {
                        playertrigger.inRangeChest = false;
                        playertrigger.inRangeDialogue = false;
                        playertrigger.inRangeDoor = false;
                        gm.playeroutside = false;
                        gm.GetComponent<SceneManagementSystem>().SceneChange("InsideBuilding");
                    } else {
                        Debug.Log(gm.GetComponent<SceneManagementSystem>().CheckScene());
                    }
                } else if(playertrigger.inRangeChest == true) 
                {
                    
                }
            }
        }

        if (Input.GetButtonDown("Fire2"))//Back Button AKA:B
        {
            
        }

        if (Input.GetButtonDown("Fire3"))// AKA:Y
        {
            
        }

        if (Input.GetButtonDown("Jump"))// AKA:X
        {
            
        }
    }
    void Movement2D() {
        anim.SetFloat("VelX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("VelY", Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") > 0.5f && (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f))//Right
        {

            anim.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector2.right * moveSpeed);
            playertrigger.GetComponent<BoxCollider2D>().offset = new Vector2(0.2f, 0.0f);
            playertrigger.GetComponent<BoxCollider2D>().size = new Vector2(0.02f, 0.29f);
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5f && (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f))//Left
        {

            anim.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector2.left * moveSpeed);
            playertrigger.GetComponent<BoxCollider2D>().offset = new Vector2(-0.2f, 0.0f);
            playertrigger.GetComponent<BoxCollider2D>().size = new Vector2(0.02f, 0.29f);
        }
        else if (Input.GetAxisRaw("Vertical") > 0.5f && (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f))//Forwards
        {

            anim.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector2.up * moveSpeed);
            playertrigger.GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, 0.25f);
            playertrigger.GetComponent<BoxCollider2D>().size = new Vector2(0.07f, 0.13f);
        }
        else if (Input.GetAxisRaw("Vertical") < -0.5f && (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f))//Backwards
        {

            anim.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector2.down * moveSpeed);
            playertrigger.GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, -0.25f);
            playertrigger.GetComponent<BoxCollider2D>().size = new Vector2(0.07f, 0.13f);
        }
        else
        {

            anim.SetFloat("IdleX", idleX);
            anim.SetFloat("IdleY", idleY);
            anim.SetBool("Movement", false);

        }
    }
    void Movement3D()
    {
        anim.SetFloat("VelX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("VelY", Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") > 0.5f && Input.GetAxisRaw("Vertical") == 0.0f)
        {

            anim.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector3.right * moveSpeed);
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5f && Input.GetAxisRaw("Vertical") == 0.0f)
        {

            anim.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector3.left * moveSpeed);
        }
        else if (Input.GetAxisRaw("Vertical") > 0.5f && Input.GetAxisRaw("Horizontal") == 0.0f)
        {

            anim.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector3.forward * moveSpeed);
        }
        else if (Input.GetAxisRaw("Vertical") < -0.5f && Input.GetAxisRaw("Horizontal") == 0.0f)
        {

            anim.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));
            idleX = anim.GetFloat("IdleX");
            idleY = anim.GetFloat("IdleY");
            anim.SetBool("Movement", true);

            transform.Translate(Vector3.back * moveSpeed);
        }
        else
        {

            anim.SetFloat("IdleX", idleX);
            anim.SetFloat("IdleY", idleY);
            anim.SetBool("Movement", false);

        }
    }
}
