using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimIncP2 : MonoBehaviour
{
    public Interact_Incorrect_P2 wrongFloor;
    public float speed = 50.0f;
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
