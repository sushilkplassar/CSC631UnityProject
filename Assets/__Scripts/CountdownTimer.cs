using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    ConnectionManager cManager;
    MessageQueue msgQueue;
    public List<GameObject> players = new List<GameObject>();

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
        Debug.Log("Callback started");
        msgQueue.AddCallback(Constants.SMSG_TIMER, ResponseTopScore);
        Debug.Log("Callback called");
        Debug.Log("Starting Coroutine");
        //StartCoroutine(RequestHeartbeat(1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (finished == true)
        {
            return;
        }
        currentTime += Time.deltaTime;
        int seconds = (int)(currentTime % 60);
        print(seconds);
        //int seconds = (int)(currentTime % 60);
        //int minutes = (int)(currentTime / 60) % 60;
        //int hours = (int)(currentTime / 3600) % 24;
        //string timeString = string.Format("{0:0}:{1:00}:{2:00 }", hours, minutes, seconds);
        ////print("Time left: " + currentTime);
        //countDownText.text = seconds;

        if (seconds > 10)
        {
            finished = true;

            /*RequestSaveScore requestSaveScore = new RequestSaveScore();
            requestSaveScore.send(1, seconds);
            Debug.Log("reqTimer: " + requestSaveScore);
            cManager.send(requestSaveScore);

            Debug.Log("Sent");*/

             RequestTopScore requestTopScore = new RequestTopScore();
             requestTopScore.send(1, seconds);
             Debug.Log("reqTimer: " + requestTopScore);
             cManager.send(requestTopScore);

             Debug.Log("Sent"); 
        }
    }
    //public void Finish()
    //{
    //    finished = true;
    //}


        public void ResponseTopScore(ExtendedEventArgs eventArgs)
    {
        Debug.Log("Callback for MessageReceived");
        ResponseTimeEventArgs args = eventArgs as ResponseTimeEventArgs;
        //  GameObject readyScreen = player.transform.GetChild(1).gameObject;

    }
    public IEnumerator RequestHeartbeat(float time)
    {

        Debug.Log("In Coroutine");
        ConnectionManager cManager = gameObject.GetComponent<ConnectionManager>();


        RequestHeartbeat request = new RequestHeartbeat();
        request.send();

        cManager.send(request);

        yield return new WaitForSeconds(time);
        //StartCoroutine(RequestHeartbeat(1f));
    }
}
