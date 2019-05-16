using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAudio : MonoBehaviour
{
    public bool alreadyEntered = false;
    public AudioSource source;
    
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            source.GetComponent<AudioSource>().Play();
        }
    }
}
