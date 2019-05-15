using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGateBehind : MonoBehaviour
{

    public SlideObject_Rev slideRev;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            slideRev.tileStepped = true;
        }
    }
}
