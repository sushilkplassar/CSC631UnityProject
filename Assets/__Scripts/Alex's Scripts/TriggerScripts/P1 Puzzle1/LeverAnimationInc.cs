using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimationInc : MonoBehaviour
{
    
    public Interact_Incorrect wrongFloor;
    public float speed = 15.0f;
    void Update()
    {
        if (wrongFloor.ePressed == true)
        {
            if (transform.rotation.x > 0)
            {
                transform.Rotate(Vector3.left * speed * Time.deltaTime);
            } else {
                wrongFloor.ePressed = false;
            }
        }
    }
        
}
