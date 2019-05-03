using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectSound : MonoBehaviour
{
    public LeverAnimationInc cc;
    void Update()
    {
        if (cc.wrongFloor.ePressed == true && GetComponent<AudioSource>().isPlaying == false)
        {

            GetComponent<AudioSource>().volume = Random.Range(0.4f, 0.6f);
            GetComponent<AudioSource>().Play();
        }
    }
}
