using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyOptions : MonoBehaviour
{
    GameObject main;
    //public GameObject readyButton;
    Main manager;

    public void readyUp()
    {
        main = GameObject.Find("Heartbeat");
        manager = main.GetComponent<Main>();
        manager.RequestReady();
    }

    public void checkReady()
    {
        
        //Toggle isReady = readyButton.GetComponent<Toggle>();
        if(this.gameObject.GetComponent<Toggle>().isOn)
        {
            readyUp();
        }
    }

    /* Player 2 clicks ready
     * sends to server
     * player 1 screen shows that player 2 is ready
     * 
     * player 1 clicks ready
     * sends to server
     * player 2 screen shows that player 1 is ready
     */

}
