using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideWall : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform originMarker;
    public Transform endMarker;
    public GameObject wallPos;

    public float speed = 1.0F;

    public bool tileStepped = false;
    
    void Update()
    {
        if (tileStepped == true)
        {
            StartCoroutine(delay());
            if(wallPos.transform.position == endMarker.position)
            {
                tileStepped = false;
            }
        } else {
            StartCoroutine(revert());
        }

        
    }

    public bool getIsStepped()
    {
        return tileStepped;
    }

    IEnumerator revert ()
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = Vector3.MoveTowards(wallPos.transform.position, originMarker.position, speed * Time.deltaTime);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = Vector3.MoveTowards(wallPos.transform.position, endMarker.position, speed * Time.deltaTime);
    }
}
