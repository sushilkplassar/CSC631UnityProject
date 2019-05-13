using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject player1Cam;

    void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            playerCam.SetActive(false);
            player1Cam.SetActive(true);
            
            GameObject.Find("Player 1").GetComponent<ClientSide_Movement>().speed = 0;
            GameObject.Find("Player 2").GetComponent<ClientSide_Movement>().speed = 3;

            GameObject.Find("Player 1").GetComponent<MouseLook>().enabled = false;
            GameObject.Find("Player 2").GetComponent<MouseLook>().enabled = true;
        }

        if(Input.GetKeyDown("1"))
        {
            player1Cam.SetActive(false);
            playerCam.SetActive(true);
            
            GameObject.Find("Player 2").GetComponent<ClientSide_Movement>().speed = 0;
            GameObject.Find("Player 1").GetComponent<ClientSide_Movement>().speed = 3;

            GameObject.Find("Player 1").GetComponent<MouseLook>().enabled = true;
            GameObject.Find("Player 2").GetComponent<MouseLook>().enabled = false;
        }
    }
}
