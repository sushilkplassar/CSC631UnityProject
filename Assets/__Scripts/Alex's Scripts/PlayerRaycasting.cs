using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component for: Main Camera
public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToSee;
    RaycastHit whatIsHit; // stores what is hit in this variable

    // Update is called once per frame
    void Update()
    {
        // visual representation of ray
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);
    }
}
