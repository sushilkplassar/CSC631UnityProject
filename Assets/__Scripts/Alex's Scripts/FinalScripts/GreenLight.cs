using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLight : MonoBehaviour
{
    public bool alreadyEntered = false;
    public EnableLight[] lights;
    public AudioSource[] audiosource;

    void OnTriggerEnter (Collider col)
    {
        if (alreadyEntered != true)
        {
            if (col.gameObject.tag == "Player")
            {
                lights[0].myLight.enabled = !lights[0].myLight.enabled;
                lights[1].myLight.enabled = !lights[1].myLight.enabled;
                audiosource[0].GetComponent<AudioSource>().Play();
                audiosource[1].GetComponent<AudioSource>().Play();
                alreadyEntered = true;
            }
        }
    }
}
