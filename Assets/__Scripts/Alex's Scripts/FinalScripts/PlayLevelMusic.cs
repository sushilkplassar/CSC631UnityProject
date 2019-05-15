using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevelMusic : MonoBehaviour
{
    public bool alreadyEntered = false;
    public AudioSource[] source;
    
    void OnTriggerEnter (Collider col)
    {
        if (alreadyEntered != true)
        {
            if (col.gameObject.tag == "Player")
            {
                source[0].GetComponent<AudioSource>().Play();
                source[1].GetComponent<AudioSource>().Stop();
                alreadyEntered = true;
            }
        }
    }
}
