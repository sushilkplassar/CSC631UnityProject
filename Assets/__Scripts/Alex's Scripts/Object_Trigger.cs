using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Trigger : MonoBehaviour
{
    public SlideWall[] slideWall;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.tag == "WallSlideL")
        {
            slideWall[0].tileStepped = true;
            slideWall[1].tileStepped = true;
        }

        if (hit.gameObject.tag == "WallSlideR")
        {
            slideWall[2].tileStepped = true;
            slideWall[3].tileStepped = true;
        }
    }
}
