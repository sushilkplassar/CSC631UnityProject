using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayerComponents : MonoBehaviour
{
    private GameObject player;
    public Canvas readyScreen;
    public int gameStart = 0;

    public void activateComponents()
    {

        // create request to say that game started by sending the number 1
        player = this.gameObject;
        player.GetComponent<FPMovement>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<MouseLook>().enabled = true;
        player.GetComponentInChildren<Camera>().GetComponent<MouseLook>().enabled = true;

        //In For AlexPlayerSpawns
        player.GetComponentInChildren<Camera>().GetComponent<MouseLock>().enabled = true;

    }

    // Start game and remove UI ready screen for player that joined. 
    public void gameStarted()
    {
        gameStart = 1;
        activateComponents();
        //readyScreen.enabled = false;
    }
}
