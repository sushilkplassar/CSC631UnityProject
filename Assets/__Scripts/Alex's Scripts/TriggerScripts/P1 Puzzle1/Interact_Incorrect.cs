using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Incorrect : MonoBehaviour
{
    // Object that is to be slide/moved
    public DestroyTorch interact;
    public FadeText text;
    
    void Update()
    {
        if (interact.inZone == true)
        {
            if (Input.GetKeyDown("e"))
            {
                interact.destroyTorch();
                interact.inZone = false;
            }
        }
    } 

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.name == "Player 2")
        {
            interact.inZone = true;
            text.stepOn = true;
        }
    }

    void OnTriggerExit()
    {
        text.stepOff = true;
    }

    
}
