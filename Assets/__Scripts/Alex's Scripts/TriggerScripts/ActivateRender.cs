using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRender : MonoBehaviour
{
    public bool inZone = false;
    public EnableRender[] rend;

    void Update()
    {
        if (inZone == true)
        {
            if (Input.GetKeyDown("e"))
            {
                //// P2 Walls
                //rend[0].renderObject.enabled = !rend[0].renderObject.enabled;
                //rend[1].renderObject.enabled = !rend[1].renderObject.enabled;

                //// P1 Walls
                
                //rend[2].renderObject.enabled = !rend[2].renderObject.enabled;
                //rend[3].renderObject.enabled = !rend[3].renderObject.enabled;

            }
        }
    } 

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inZone = true;
        }
    }

    void OnTriggerExit()
    {
        inZone = false;
    }
}
