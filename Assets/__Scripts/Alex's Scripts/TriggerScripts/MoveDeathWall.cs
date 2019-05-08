using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDeathWall : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    //public Transform originMarker;
    public Transform endMarker;
    public Transform endMarker2;
    public GameObject wallPos;
    
    public float speed = 1.0F;
    public bool tileStepped = false;
    public int tries = 0;

    // Update is called once per frame
    void Update()
    {
        if (tileStepped == true)
        {
            StartCoroutine(moveToMarker());
             if(wallPos.transform.position == endMarker.position)
            {
                tileStepped = false;

                tries += 1;
                if (tries == 1)
                {
                    endMarker.position = endMarker2.position;
                }
            }
        }
    }

    IEnumerator moveToMarker()
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = Vector3.MoveTowards(wallPos.transform.position, endMarker.position, speed * Time.deltaTime);
    }
}
