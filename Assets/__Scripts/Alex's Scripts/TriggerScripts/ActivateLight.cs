using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLight : MonoBehaviour
{
    public bool inZone = false;
    public bool ePressed = false;
    public EnableLight[] lights;
    
    void Update()
    {
        if (inZone == true)
        {
            if (Input.GetKeyDown("e"))
            {
                ePressed = true;
                lights[0].myLight.enabled = !lights[0].myLight.enabled;
                lights[1].myLight.enabled = !lights[1].myLight.enabled;
                lights[2].myLight.enabled = !lights[2].myLight.enabled;
                //inZone = false;
            }
        }
    } 

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.name == "Player 2")
        {
            inZone = true;
        }
    }

    void OnTriggerExit()
    {
        inZone = false;
    }
}
