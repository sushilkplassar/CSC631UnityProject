using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public SlideWall door;
    public AudioClip source;
    void Update()
    {
        if (door.playSound == true && GetComponent<AudioSource>().isPlaying == false)
        {

            //GetComponent<AudioSource>().volume = Random.Range(0.4f, 0.6f);
            //GetComponent<AudioSource>().PlayOneShot(source, 0.6f);
        }
    }
}
