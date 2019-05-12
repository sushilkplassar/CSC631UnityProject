using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component for:   Objects that checks for player entering Trigger Zone

// Other Components:    Rigidbody (Use Gravity UNCHECKED)
//                      Box Collider (Is Trigger CHECKED)
//                      Mesh Renderer (UNCHECKED)

// Hierarchy Requirement:   Duplicate this Object
//                          Leave only default components
//                          Mesh Renderer (CHECKED)
//                          Box Collider (Is trigger UNCHECKED)

// Scene Requirement:   Move Original Object (the one with this script)
//                      above the duplicate Object
//                      This (the original object) will be the "Trigger Zone"


// Script Requirement:  Reference Object that is to be slid/moved

public class TriggerZone_Stay : MonoBehaviour
{
    // Object that is to be slide/moved
    public SlideObject_Stay slideStay; 

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            slideStay.tileStepped = true;
        }
    }
}
