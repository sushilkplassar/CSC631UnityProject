using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimIncP2 : MonoBehaviour
{
    public Interact_Incorrect_P2 wrongFloor;
    public float speed = 15.0f;
    void Update()
    {
        if (wrongFloor.ePressed == true)
        {
            Vector3 destination = new Vector3(30,0,0);
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles,
             destination, 
             speed * Time.deltaTime);
        }
    }
}
