using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneRev : MonoBehaviour
{
    // Object that is to be slide/moved
    public SlideObject_Stay[] slideStay;
    public SlideObject_Rev[] slideRev;

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //if(slideRev[1].tileStepped = false)
            //{
                slideStay[0].tileStepped = true;
                slideStay[1].tileStepped = true;
            //}
        }
    }

    void OnTriggerExit()
    {
        //if(slideStay[1].tileStepped = false)
        //{
            slideRev[0].tileStepped = true;
            slideRev[1].tileStepped = true;
        //}
    }
}