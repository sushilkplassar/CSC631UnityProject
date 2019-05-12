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

    Main manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("heartbeat").GetComponent<Main>();
    }

    void Update()
    {
        if (inZone == true)
        {
            if (Input.GetKeyDown("e"))
            {
                ePressed = true;
                slideStay.tileStepped = true;
                inZone = false;
                // Half way done
                if(this.gameObject.tag == "Puzzle2")
                {
                    manager.RequestP2Triggers(1);
                }
                else if (this.gameObject.tag == "Puzzle2Finish")
                {
                    manager.RequestP2Triggers(2);
                }

            }
        }
    } 

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
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
