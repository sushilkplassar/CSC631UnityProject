using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioEpressed : MonoBehaviour
{
    public AudioSource source;

    public Interact_Correct correctFloor;
    bool onetime = false;

    void Update()
    {
        if (correctFloor.ePressed == true)
        {
            if (!onetime)
            {
                source.GetComponent<AudioSource>().Play();
                onetime = true;
            }
        }
    }
}
