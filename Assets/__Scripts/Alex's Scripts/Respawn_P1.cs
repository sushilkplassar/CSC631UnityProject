using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_P1 : MonoBehaviour
{
    [SerializeField] private Transform respawn;
    [SerializeField] private Transform player;

    private FPMovement changeSpeed;
    public Animator animator;
    private bool isDeath = false;

    void Start()
    {
        GameObject g = GameObject.Find("Player2");
        changeSpeed = g.GetComponent<FPMovement> ();
    }

    void FixedUpdate()
    {
        if(isDeath == true)
        {
            changeSpeed.speed = 0.5f;
        } 
    }

    IEnumerator OnControllerColliderHit(ControllerColliderHit hit)
    {
         if (hit.gameObject.tag == "Respawn")
        {   
            
            isDeath = true;
            player.transform.position = respawn.position;
            yield return new WaitForSeconds(0.5f);
            changeSpeed.speed = 4f;
            isDeath = false;
            //animator.SetTrigger("FadeOut");
        }
    }
}