using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxControllerSystem : MonoBehaviour
{
    public bool buttonA;
    public bool buttonB;
    public bool buttonY;
    public bool buttonX;
    public bool buttonLT;
    public bool buttonRT;
    public bool buttonLB;
    public bool buttonRB;
    public bool buttonBack;
    public bool buttonStart;
    public float Hor;
    public float Ver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("A")) {
            buttonA = true;
        } else if(Input.GetButtonUp("A")) {
            buttonA = false;
        }

        if(Input.GetButtonDown("B")) {
            buttonB = true;
        } else if(Input.GetButtonUp("B")) {
            buttonB = false;
        }

        if(Input.GetButtonDown("Y")) {
            buttonY = true;
        } else if(Input.GetButtonUp("Y")) {
            buttonY = false;
        }

        if(Input.GetButtonDown("X")) {
            buttonX = true;
        } else if(Input.GetButtonUp("X")) {
            buttonX = false;
        }

        if(Input.GetButtonDown("LT")) {
            buttonLT = true;
        } else if(Input.GetButtonUp("LT")) {
            buttonLT = false;
        }

        if(Input.GetButtonDown("RT")) {
            buttonRT = true;
        } else if(Input.GetButtonUp("RT")) {
            buttonRT = false;
        }

        if(Input.GetButtonDown("LB")) {
            buttonLB = true;
        } else if(Input.GetButtonUp("LB")) {
            buttonLB = false;
        }

        if(Input.GetButtonDown("RB")) {
            buttonRB = true;
        } else if(Input.GetButtonUp("RB")) {
            buttonRB = false;
        }

        if(Input.GetButtonDown("Back")) {
            buttonBack = true;
        } else if(Input.GetButtonUp("Back")) {
            buttonBack = false;
        }

        if(Input.GetButtonDown("Start")) {
            buttonStart = true;
        } else if(Input.GetButtonUp("Start")) {
            buttonStart = false;
        }

        if(Input.GetAxisRaw("XboxHorizontal") != 0.0f) {
            Hor = Input.GetAxisRaw("XboxHorizontal");
        } else {
            Hor = Input.GetAxisRaw("XboxHorizontal");
        }

        if(Input.GetAxisRaw("XboxVertical") != 0.0f) {
            Ver = Input.GetAxisRaw("XboxVertical");
        } else {
            Ver = Input.GetAxisRaw("XboxVertical");
        }
    }
}
