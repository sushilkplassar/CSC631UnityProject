using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeathWall : MonoBehaviour
{
    public Lerp_Tile lerpWall;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Trigger")
        {   
            lerpWall.steppedOn = true;
        }
    }
}
