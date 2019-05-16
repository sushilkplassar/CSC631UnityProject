using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyOptions : MonoBehaviour
{
    public GameObject main;
    //public GameObject readyButton;
    public Main manager;
    public GameObject screen;
    public bool submitted = false;


    private void Awake()
    {
        main = GameObject.FindGameObjectWithTag("heartbeat");
        screen = GameObject.FindGameObjectWithTag("timeScreen");
    }
    private void Start()
    {
        manager = main.GetComponent<Main>();
    }

    public void readyUp()
    {
        
        manager.RequestReady();
    }

    public void notReady()
    {

        manager.RequestUnready();
    }

    public void checkReady()
    {
        
        //Toggle isReady = readyButton.GetComponent<Toggle>();
        if(this.gameObject.GetComponent<Toggle>().isOn)
        {
            readyUp();
        }
        else if(!this.gameObject.GetComponent<Toggle>().isOn)
        {
            notReady();
        }
    }

    public void getHighscore()
    {
        // Show Best Time Screen
        manager.RequestGetScores();
        screen.GetComponent<Canvas>().enabled = true;
        // Turn off End menu screen
        GameObject.FindGameObjectWithTag("EndMenu").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("TeamNameWindow").GetComponent<Upload>().enabled = false;

        

    }

    public void returnToMenu()
    {
        submitted = false;
        GameObject.FindGameObjectWithTag("TeamNameWindow").GetComponent<Upload>().enabled = false;
        GameObject.FindGameObjectWithTag("EndMenu").GetComponent<Canvas>().enabled = false;
        screen.GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene(1);
    }

    public void startGame()
    {
        manager.RequestStart();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void backToEndMenu()
    {
        screen.GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("EndMenu").GetComponent<Canvas>().enabled = true;
        // Can't upload again if they didn't submit and return back after viewing high scores
        if (submitted)
        {
            GameObject.FindGameObjectWithTag("TeamNameWindow").GetComponent<Upload>().enabled = false;
        } else
        {
            GameObject.FindGameObjectWithTag("TeamNameWindow").GetComponent<Upload>().enabled = true;
        }
    }

}
