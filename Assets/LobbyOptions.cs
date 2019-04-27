using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyOptions : MonoBehaviour
{
    GameObject main;
    //public GameObject readyButton;
    Main manager;

    private void Awake()
    {
        main = GameObject.Find("Heartbeat");
        manager = main.GetComponent<Main>();
    }

    public void readyUp()
    {
        
        manager.RequestReady();
    }

    public void checkReady()
    {
        
        //Toggle isReady = readyButton.GetComponent<Toggle>();
        if(this.gameObject.GetComponent<Toggle>().isOn)
        {
            readyUp();
        }
        else if(this.gameObject.GetComponent<Toggle>().isOn == false)
        {
            Debug.Log("Unready");
        }
    }

    public void startGame()
    {
        manager.RequestStart();
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
