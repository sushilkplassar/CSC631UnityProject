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
        slideWall[4] = GameObject.FindGameObjectWithTag("WallSlideL2").GetComponent<SlideWall>();
        slideWall[5] = GameObject.FindGameObjectWithTag("WallSlideR2").GetComponent<SlideWall>();
    }
    // tiles that are stepped on

    private void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.tag == "Trigger")
        {
            //lerpWall.steppedOn = true;
        }
        if (hit.gameObject.tag == "WallSlideL2")
        {
            slideWall[0].tileStepped = true;
            slideWall[1].tileStepped = true;

        }


        if (hit.gameObject.tag == "WallSlideR2")
        {
            slideWall[2].tileStepped = true;
            slideWall[3].tileStepped = true;
        }

        // player 2 puzzle 2 walls
        if (hit.gameObject.tag == "P2WallSlideD")
        {
            slideWall[4].tileStepped = true;
            slideWall[5].tileStepped = true;
        }
    }

}
