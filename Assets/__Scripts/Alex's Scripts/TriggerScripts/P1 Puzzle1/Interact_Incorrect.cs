using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Incorrect : MonoBehaviour
{
    // Object that is to be slide/moved
    public DestroyTorch interact;
    private FadeText text;
    // Player Object is a child of the Player Spawn Game Object.



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
        if (col.gameObject.tag == "Player")
        {
            interact.inZone = true;
           // text.stepOn = true;
        }
    }

    /*
    void OnTriggerExit()
    {
        text.stepOff = true;
    }*/

    
}
