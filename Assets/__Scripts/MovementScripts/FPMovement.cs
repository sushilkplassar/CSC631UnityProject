using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class FPMovement : MonoBehaviour
{
    public float speed = 12.0f;
    float gravity = -9.8f;

    private float verticalVelocity;
    private float jumpForce = 15.0f;
    private float gravityJump = 14.0f;
    private GameObject heartbeat;
    ConnectionManager manager;

    private CharacterController characterControl;

    private void Awake()
    {
        heartbeat= GameObject.Find("Heartbeat");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Access character controller component on same object this file is attatched on
        characterControl = GetComponent<CharacterController>();
        manager = heartbeat.GetComponent<ConnectionManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "Player")
        {

            //  movePlayer("Vertical", "Horizontal");
            movePlayer();
        }

        // Need testing with either Input.anyKeyDown or Input.anyKey
        // They both work similarly but need to find which one is better.
        // anyKeyDown seems instant.
        // anyKey shows every step of the way of it moving.
        if (Input.anyKey)
        {
            

                manager.send(moving(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
            

            // Request movement after moving in Unity?
            Debug.Log("Sending request to move.");
        }
        /*
       else if (this.gameObject.tag == "Player2")
        {
            movePlayer("Vertical2", "Horizontal2");
        }
        */
        

    }

    
    public RequestMove moving(float posX, float posY, float posZ)
    {
        RequestMove move = new RequestMove();
        move.send(posX, posY, posZ);
        return move;
    }
    public void movePlayer()
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

        /* if (characterControl.isGrounded)
         {
             verticalVelocity = -gravityJump * Time.deltaTime;
             if (Input.GetKeyDown(KeyCode.Space))
             {
                 verticalVelocity = jumpForce;
             }
         }
         else
         {
             verticalVelocity -= gravityJump * Time.deltaTime;
         }
         Vector3 jumpVector = new Vector3(0, verticalVelocity, 0);
         characterControl.Move(jumpVector * Time.deltaTime);*/

    }

    
}




