using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{

     // Transforms to act as start and end markers for the journey.
    public GameObject block;
    public Transform rightMarker;
    public Transform middleMarker;
    public Transform botRightMarker;
    public Transform endMarker;
    public Transform endLeftMarker;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;
    private bool steppedOn = false;
    private bool left = false;
    private bool right = false;
    private bool middle = false;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;
        // Calculate the journey length.
        journeyLength = Vector3.Distance(block.transform.position, endMarker.position);
    }

    // Follows the target position like with a spring
    void Update()
    {
        onMarker();
        if (steppedOn == true)
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;
            
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(block.transform.position, endMarker.position, fracJourney);
        }
    }

    void onMarker()
    {
        // block on right marker
        if (block.transform.position == rightMarker.position)
        {
            // block moves down
            if(Input.GetKeyDown(KeyCode.Space))
            {
                endMarker.position = botRightMarker.position;
                steppedOn =  true;
            }
            
        }

        //block on bottom right marker
        if (block.transform.position == botRightMarker.position)
        {
            if (gameObject.transform.position != rightMarker.position)
            {
                // block moves up
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    endMarker.position = rightMarker.position;
                    steppedOn =  true;
                }
            }
        }
        
        //keep moving left
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(gameObject.transform.position != endLeftMarker.position)
            {
                if (block.transform.position == rightMarker.position)
                {
                    endMarker.position = middleMarker.position;
                    steppedOn = true;
                }

                if (block.transform.position == middleMarker.position)
                {
                    endMarker.position = endLeftMarker.position;
                    steppedOn = true;
                }
            }

        }
        /*
         // block on middle marker
        if (block.transform.position == middleMarker.position)
        {
            // block moves right
            if(Input.GetKeyDown(KeyCode.M))
            {
                endMarker.position = rightMarker.position;
                steppedOn =  true;
            }
            
        } */
    }
}
