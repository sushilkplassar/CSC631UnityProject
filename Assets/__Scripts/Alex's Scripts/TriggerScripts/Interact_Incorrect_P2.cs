using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Incorrect_P2 : MonoBehaviour
{
    public MoveDeathWall moveWall;
    public bool inZone = false;
    public bool ePressed = false;

    Main manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("heartbeat").GetComponent<Main>();
    }

    void Update()
    {
        if (inZone == true)
        {
            if (Input.GetKeyDown("e"))
            {
                // P2 meaning Puzzle 2 triggers in this case, not the player
                manager.RequestP2Incorrect(int.Parse(this.gameObject.tag));
                ePressed = true;
                moveWall.tileStepped = true;
                //interact.destroyTorch();
                inZone = false;
                
            }
        }
    } 

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inZone = true;
        }
    }

    void OnTriggerExit()
    {
        inZone = false;
        ePressed = false;
    }
}
