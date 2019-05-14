using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimation : MonoBehaviour
{
    public Interact_Correct correctFloor;
    public float speed = 50.0f;
    void Update()
    {
        if (correctFloor.ePressed == true)
        {
            if (transform.rotation.x > 0)
            {
                transform.Rotate(Vector3.left * speed * Time.deltaTime);
            } else {
                correctFloor.ePressed = false;
            }
        }
    }
        
}
