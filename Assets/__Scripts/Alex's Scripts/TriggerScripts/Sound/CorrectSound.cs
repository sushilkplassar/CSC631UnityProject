using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectSound : MonoBehaviour
{
    public LeverAnimation cc;
    void Update()
    {
        if (cc.correctFloor.ePressed == true && GetComponent<AudioSource>().isPlaying == false)
        {

            GetComponent<AudioSource>().volume = Random.Range(0.4f, 0.6f);
            GetComponent<AudioSource>().Play();
        }
    }
}
