using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeathWall : MonoBehaviour
{
    public Lerp_Tile lerpWall;
    public SlideWall[] slideWall;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Trigger")
        {   
            lerpWall.steppedOn = true;
        }

        if (hit.gameObject.tag == "WallSlide")
        {
            slideWall[0].tileStepped = true;
            slideWall[1].tileStepped = true;
            slideWall[2].tileStepped = true;
        }
    }
}
