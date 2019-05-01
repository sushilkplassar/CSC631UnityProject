using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameAudio : MonoBehaviour
{
    public AudioSource source;
    //public AudioClip hover; 
    public AudioClip click;


    public void Onhover()
    {
      //source.PlayOneShot(hover);
    }
    
    public void Onclick()
    {
        source.PlayOneShot(click);
    }

}
