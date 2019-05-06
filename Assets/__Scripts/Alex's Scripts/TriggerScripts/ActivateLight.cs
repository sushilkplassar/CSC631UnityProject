﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLight : MonoBehaviour
{
    public bool inZone = false;
    
    public EnableLight[] lights;
    
    void Update()
    {
        if (inZone == true)
        {
            if (Input.GetKeyDown("e"))
            {
                // P1 Torch
                lights[0].myLight.enabled = !lights[0].myLight.enabled;
                // P1 WallLight
                lights[1].myLight.enabled = !lights[1].myLight.enabled;

                // P2 LightColors
                lights[2].myLight.enabled = !lights[2].myLight.enabled;
                // P2 WallLight
                lights[3].myLight.enabled = !lights[3].myLight.enabled;

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
