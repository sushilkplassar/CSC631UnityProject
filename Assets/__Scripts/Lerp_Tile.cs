using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp_Tile : MonoBehaviour
{
     // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0F;

    public bool steppedOn = false;
    public bool stopWall = false;
    
    void Update()
    {
        if (steppedOn == true)
        {
            transform.position = Vector3.MoveTowards(startMarker.position, endMarker.position, speed * Time.deltaTime);
            
            if(stopWall == true)
            {
                endMarker.position = startMarker.position;
            }
            
        }
    }
}
