using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moves objects to endMarker and stays there
public class SlideObject_Stay : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform originMarker;
    public Transform endMarker;
    public GameObject wallPos;
    
    public float speed = 1.0F;
    public bool tileStepped = false;

    // Update is called once per frame
    void Update()
    {
        if (tileStepped == true)
        {
            StartCoroutine(moveToMarker());
             if(wallPos.transform.position == endMarker.position)
            {
                tileStepped = false;
            }
        }
    }

    IEnumerator moveToMarker()
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = Vector3.MoveTowards(wallPos.transform.position, endMarker.position, speed * Time.deltaTime);
    }
}
