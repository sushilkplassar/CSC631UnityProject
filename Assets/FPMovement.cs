using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    public float speed = 12.0f;
    float gravity = -9.8f;

    private CharacterController characterControl;
    // Start is called before the first frame update
    void Start()
    {
        //access character controller component on same object this file is attatched on
        characterControl = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveForwardAndBack = Input.GetAxis("Vertical") * speed; // forward and backward movements is Z axis
        float moveSideToSide = Input.GetAxis("Horizontal") * speed; // moving side to side is X axis

        // for moving the character controller
        Vector3 characterMovement = new Vector3(moveSideToSide, 0, moveForwardAndBack);
        characterMovement = Vector3.ClampMagnitude(characterMovement, speed); //diagonal speed is fixed

        characterMovement.y = gravity;
        characterMovement *= Time.deltaTime; //frame independent movement
        characterMovement = transform.TransformDirection(characterMovement); // convert local to global coordinates

        characterControl.Move(characterMovement);
       
    }
}
