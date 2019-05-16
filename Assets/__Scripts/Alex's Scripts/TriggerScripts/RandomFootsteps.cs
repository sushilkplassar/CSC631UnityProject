using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFootsteps : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] shoot;
    private AudioClip shootClip;
    CharacterController cc;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.magnitude > 1f 
            && GetComponent<AudioSource>().isPlaying == false)
        {
            int index = Random.Range(0, shoot.Length);
            shootClip = shoot[index];
            audioSource.clip = shootClip;
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
        }
     }
}
