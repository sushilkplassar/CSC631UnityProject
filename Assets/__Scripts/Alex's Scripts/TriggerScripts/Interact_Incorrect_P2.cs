using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Incorrect_P2 : MonoBehaviour
{
    public MoveDeathWall[] moveWall;
    public bool inZone = false;
    public bool ePressed = false;
    
    void Update()
    {
        if (inZone == true)
        {
            if (Input.GetKeyDown("e"))
            {
                ePressed = true;
                moveWall[0].tileStepped = true;
                moveWall[1].tileStepped = true;
                //interact.destroyTorch();
                inZone = false;
            }
        }
    } 

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inZone = true;
        }
    }

    void OnTriggerExit()
    {
        inZone = false;
        ePressed = false;
    }
}
