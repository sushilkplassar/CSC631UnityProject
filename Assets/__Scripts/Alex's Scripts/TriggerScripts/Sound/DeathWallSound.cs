using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallSound : MonoBehaviour
{
    public MoveDeathWall wall;
    void Update()
    {
        if (wall.tileStepped == true && GetComponent<AudioSource>().isPlaying == false)
        {

            //GetComponent<AudioSource>().volume = Random.Range(0.4f, 0.6f);
            GetComponent<AudioSource>().Play();
        }
    }
}
