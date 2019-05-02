using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    public SlideWall[] slideWall;
    private bool P1sendDoorForward = false;
    private bool P1sendMoveDoorBack = false;
    private bool P2sendDoorForward = false;
    private bool P2sendMoveDoorBack = false;
    private void Awake()
    {
        //lerpWall = GameObject.FindGameObjectWithTag("deathwall").GetComponent<Lerp_Tile>();
        slideWall[0] = GameObject.FindGameObjectWithTag("leftdoor").GetComponent<SlideWall>();
        slideWall[1] = GameObject.FindGameObjectWithTag("WallSlideL").GetComponent<SlideWall>();
        slideWall[2] = GameObject.FindGameObjectWithTag("rightdoor").GetComponent<SlideWall>();
        slideWall[3] = GameObject.FindGameObjectWithTag("WallSlideR").GetComponent<SlideWall>();
    }
    // tiles that are stepped on

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Trigger")
        {   
            //lerpWall.steppedOn = true;
        }
        if (hit.gameObject.tag == "WallSlideL")
        {
            slideWall[0].tileStepped = true;
            slideWall[1].tileStepped = true;
            if (P1sendDoorForward == false)
            {
                P1sendDoorForward = true;
                P1sendMoveDoorBack = false;
                Debug.Log("*********************************************Send Request to move left door.");
            }
        } else
        {
            if(P1sendMoveDoorBack == false && P1sendDoorForward == true)
            {
                P1sendMoveDoorBack = true;
                P1sendDoorForward = false;
                Debug.Log("*********************************************Send Request to move left door BACK.");
            }
        }

        if (hit.gameObject.tag == "WallSlideR")
        {
            slideWall[2].tileStepped = true;
            slideWall[3].tileStepped = true;
            if (P2sendDoorForward == false)
            {
                P2sendDoorForward = true;
                P2sendMoveDoorBack = false;
                Debug.Log("*********************************************Send Request to move right door.");
            }
        }
        else
        {
            if (P2sendMoveDoorBack == false && P2sendDoorForward == true)
            {
                P2sendMoveDoorBack = true;
                P2sendDoorForward = false;
                Debug.Log("*********************************************Send Request to move right door BACK.");
            }
        }


        // player 2 puzzle 2 walls
        if (hit.gameObject.tag == "P2WallSlideD")
        {
            slideWall[4].tileStepped = true;
            slideWall[5].tileStepped = true;
        }
    }
}
