using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Correct : MonoBehaviour
{
    // Object that is to be slide/moved
    public SlideObject_Stay slideStay;
    bool inZone = false;
    
    public bool ePressed = false;
    
    //public FadeText text;
    
    void Update()
    {
        if (inZone == true)
        {
            if (Input.GetKeyDown("e"))
            {
                ePressed = true;
                slideStay.tileStepped = true;
                inZone = false;
            }
        }
    } 

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.name == "Player 2")
        {
            inZone = true;
            //text.stepOn = true;
        }
    }

    void OnTriggerExit()
    {
        //text.stepOff = true;
        inZone = false;
    }
}
