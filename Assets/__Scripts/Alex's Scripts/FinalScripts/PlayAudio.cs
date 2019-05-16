using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public bool alreadyEntered = false;
    public AudioSource source;
    
    void OnTriggerEnter (Collider col)
    {
        if (alreadyEntered != true)
        {
            if (col.gameObject.tag == "Player")
            {
                source.GetComponent<AudioSource>().Play();
                alreadyEntered = true;
            }
        }
    }
}
