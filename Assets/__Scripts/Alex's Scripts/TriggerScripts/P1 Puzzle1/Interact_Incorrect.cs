﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Incorrect : MonoBehaviour
{
    // Object that is to be slide/moved
    public DestroyTorch interact;
    public FadeText text;
    

    public bool inZone = false;
    public bool ePressed = false;
    
    void Update()
    {
        if (inZone == true)
        {
            if (Input.GetKeyDown("e"))
            {
                ePressed = true;
                interact.destroyTorch();
                inZone = false;
            }
        }
    } 

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.name == "Player 2")
        {
            inZone = true;
            text.stepOn = true;
        }
    }

    void OnTriggerExit()
    {
        text.stepOff = true;
        inZone = false;
    }

    
}
