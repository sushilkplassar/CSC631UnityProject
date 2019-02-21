using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPMovement : MonoBehaviour
{
    public float speed = 12.0f;
    float gravity = -9.8f;

    private CharacterController characterControl;
   
    // Start is called before the first frame update
    void Start()
    {
        // Access character controller component on same object this file is attatched on
        characterControl = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveForwardAndBack = Input.GetAxis("Vertical") * speed; // forward and backward movements is Z axis
        float moveSideToSide = Input.GetAxis("Horizontal") * speed; // Moving side to side is X axis

        // For moving the character controller
        Vector3 characterMovement = new Vector3(moveSideToSide, 0, moveForwardAndBack);
        characterMovement = Vector3.ClampMagnitude(characterMovement, speed); // Diagonal speed is fixed

        characterMovement.y = gravity;
        characterMovement *= Time.deltaTime; //frame independent movement
        characterMovement = transform.TransformDirection(characterMovement); // Convert local to global coordinates

        characterControl.Move(characterMovement);


        // To move to the next scene; 
        if (Input.GetKeyDown(KeyCode.N))
        {
            // Must add scene to build settings for this to work
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads scene based off of index scene
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // Create a new random color ever time C is pressed.
            Color color = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
            this.gameObject.GetComponent<Renderer>().material.color = color;
        }


    }
}
