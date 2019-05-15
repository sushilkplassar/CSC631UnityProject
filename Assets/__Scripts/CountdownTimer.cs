using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    ConnectionManager cManager;
    MessageQueue msgQueue;
    public List<GameObject> players = new List<GameObject>();
    private GameObject player;

    float currentTime = 0;
    //float startTime = 10f;
    [SerializeField] Text countDownText;
    public bool finished = false;

    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        NetworkRequestTable.init();
        NetworkResponseTable.init();
    }

    private void Start()
    {
        cManager = gameObject.GetComponent<ConnectionManager>();
        msgQueue = gameObject.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_TIMER, ResponseTopScore);
       
        Debug.Log("Callback started");

        Debug.Log("Callback called");
        Debug.Log("Starting Coroutine");
        StartCoroutine(RequestHeartbeat(1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (finished == true)
        {
            return;
        }
        //currentTime += Time.deltaTime;
        currentTime += 1;
        int seconds = (int)(currentTime);
        print(seconds);
        //int seconds = (int)(currentTime % 60);
        //int minutes = (int)(currentTime / 60) % 60;
        //int hours = (int)(currentTime / 3600) % 24;
        //string timeString = string.Format("{0:0}:{1:00}:{2:00 }", hours, minutes, seconds);
        ////print("Time left: " + currentTime);
        countDownText.text = seconds.ToString();
        if (seconds == 1)
        {
            finished = true;
            SendTimetoServer(seconds);
        }
    }

    public void SendTimetoServer(int seconds) { 
            //finished = true;

            //RequestSaveScore requestSaveScore = new RequestSaveScore();
            //requestSaveScore.send("def", seconds);
            //Debug.Log("reqTimer: " + requestSaveScore);
            //cManager.send(requestSaveScore);

            //Debug.Log("Sent");

             RequestTopScore requestTopScore = new RequestTopScore();
             requestTopScore.send();
             cManager.send(requestTopScore);

             Debug.Log("Sent");
        }

    public void ResponseTopScore(ExtendedEventArgs eventArgs)
    {
        Debug.Log("Callback for MessageReceived");
        ResponseTopScoreEventArgs args = eventArgs as ResponseTopScoreEventArgs;
        //  GameObject readyScreen = player.transform.GetChild(1).gameObject;
        Debug.Log("I am here in CountdownTimer.cs Script");
        //string timeReceived = args.playerID;
        string teamName = args.teamName;
        string teamTime = args.time;
        //countDownText.text = teamName + teamTime + " \n";
        string[] teams = teamName.Split(',');
        string[] timer = teamTime.Split(',');
        countDownText.text = "";
        //foreach (string team in teams)
        for (int i=0;i<teams.Length;i++)
        {
            Debug.Log("Team: " + countDownText.text);
            //countDownText.text = team + "\n";
            countDownText.text = countDownText.text + teams[i] + "\t" + timer[i]+ "\n";
        }
        //countDownText.text = timeReceived;

    }
    public IEnumerator RequestHeartbeat(float time)
    {

        Debug.Log("In Coroutine");
        cManager = gameObject.GetComponent<ConnectionManager>();


        RequestHeartbeat request = new RequestHeartbeat();
        request.send();

        cManager.send(request);

        yield return new WaitForSeconds(time);
        //StartCoroutine(RequestHeartbeat(1f));
    }
}
