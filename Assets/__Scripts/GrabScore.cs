using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Placed on end game trigger zone.

public class GrabScore : MonoBehaviour
{
    // object with the TimerControl script
    public GameObject TimerObject;
    private TimeControl grab;

    public bool stopTime = false;
    public bool alreadyEntered = false;
    
    public float score = 0f;

    void Start()
    {
        grab = TimerObject.GetComponent<TimeControl>();
    }

    void OnTriggerEnter (Collider col)
    {
        if (alreadyEntered != true)
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponentInChildren<MouseLock>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                stopTime = true;
                GrabTime();
                alreadyEntered = true;
            }
        }
    }

    public void GrabTime()
    {
        if (stopTime == true)
        {
            // store time in score 
            score = grab.timer;
            //stopTime = false;
            GameObject.FindGameObjectWithTag("EndMenu").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("TeamNameWindow").GetComponent<Upload>().enabled = true;
        }
    }
}
