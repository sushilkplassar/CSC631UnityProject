using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    [SerializeField] Text countDownText, countDownTeamName;
    ConnectionManager cManager;
    MessageQueue msgQueue;
    public List<GameObject> players = new List<GameObject>();
    private GameObject player;

    //Chat variables
    public int maxMessages = 25;
    public string username;
    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public Color playerMessage, info;
    [SerializeField]
    List<Message> messageList = new List<Message>();

    bool player1Ready = false;
    bool player2Ready = false;

    void Awake() {
        //DontDestroyOnLoad(gameObject);
        NetworkRequestTable.init();
        NetworkResponseTable.init();
    }
	
	// Use this for initialization
	void Start () {

        
        cManager = gameObject.GetComponent<ConnectionManager>();
        msgQueue = gameObject.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_AUTH, ResponseCreate);
        msgQueue.AddCallback(Constants.SMSG_MOVE, ResponseMove);
        msgQueue.AddCallback(Constants.SMSG_READY, ResponseReady);
        msgQueue.AddCallback(Constants.SMSG_START, ResponseStart);
        msgQueue.AddCallback(Constants.SMSG_UNREADY, ResponseUnready);
        msgQueue.AddCallback(Constants.SMSG_CHAT, ResponseChat);
        msgQueue.AddCallback(Constants.SMSG_LIGHT, ResponseLight);
        msgQueue.AddCallback(Constants.SMSG_P2CORRECT, ResponseP2Correct);
        msgQueue.AddCallback(Constants.SMSG_P2INCORRECT, ResponseP2Incorrect);
        msgQueue.AddCallback(Constants.SMSG_TIMER, ResponseTopScore);

        Debug.Log("Starting Coroutine");
		StartCoroutine(RequestHeartbeat(1f));
		
	}
	
	// Update is called once per frame
	void Update () {

        // For Chat
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //SendMessagetoChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);
                SendMessagetoChat(chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();
        }

    }

    // Function to be called after processing a message.
    // Function callbacks used to show what is received or what happens to the client
    // after the request is done processing from the connection manager. 
    public void ResponseCreate(ExtendedEventArgs eventArgs)
    {
        ResponseCreateEventArgs argID = eventArgs as ResponseCreateEventArgs;
        if (players.Count >= 2)
        {
           foreach(GameObject player in players)
            {
                Destroy(player);
            }
            players = new List<GameObject>();

        }
        player = spawnHere(eventArgs);
        player.tag = argID.user_id.ToString();
        players.Add(player);
            
        if (players.Count == 1)
        {
            // Activates the ready screen for player
            GameObject readyScreen = player.transform.GetChild(1).gameObject;
            readyScreen.transform.GetChild(4).gameObject.SetActive(true);
            readyScreen.transform.GetChild(5).gameObject.SetActive(true);

            // Assigning chat box field
            chatBox = GameObject.FindGameObjectWithTag("inputfield").GetComponent<InputField>();

            // Assigning chat panel field
            chatPanel = GameObject.FindGameObjectWithTag("content");
            Debug.Log("Added first player in list.");
        }
        
        // Turning off components and game objects for the other player. 
        if(players.Count > 1)
        {
            Debug.Log("Adding subsequent players that join.");

            // Player Object is a child of the Player Spawn Game Object.
            GameObject playerObject = player.transform.GetChild(0).gameObject;

            // Turn off End menu screen for the other player
            player.transform.GetChild(2).gameObject.SetActive(false);
            // Turn off all children associated with the new player object that joins.
            for (int i = 0; i < playerObject.transform.childCount; i++)
            {
                Debug.Log("Turning off camera");
                // The rest of the children is within this player. 
                GameObject child = playerObject.transform.GetChild(i).gameObject;

                // Turning off children of player. 
                if (child != null)
                    child.SetActive(false);
            }

            // Turn off canvas of other player
            player.transform.GetChild(1).gameObject.SetActive(false);
        
            // Turn off all movement and camera objects so that one input doesn't move both player objects.
            playerObject.GetComponent<FPMovement>().enabled = false;
            //playerObject.GetComponent<CharacterController>().enabled = false;
            playerObject.GetComponent<MouseLook>().enabled = false;
        }
        Debug.Log("Successfully created player in callback function.");
    }

    // Spawn players in different areas of the room based on their tag.
    public GameObject spawnHere(ExtendedEventArgs eventArgs)
    {
        GameObject spawn = null;
        // if eventArgs.playertag == 1 or eventArgs.playertag == 2 to tell them to spawn in different areas
        ResponseCreateEventArgs argID = eventArgs as ResponseCreateEventArgs;
        if (argID.user_id == 1)
        {
            spawn = Instantiate(Resources.Load<GameObject>("Prefabs/P1 Puzzle/AlexP1Spawn"));
            //spawn = Instantiate(Resources.Load<GameObject>("Prefabs/Player1Spawn"));

        }
        if (argID.user_id == 2)
        {
            spawn = Instantiate(Resources.Load<GameObject>("Prefabs/P1 Puzzle/AlexP2Spawn"));
            //spawn = Instantiate(Resources.Load<GameObject>("Prefabs/Player2Spawn"));
        }
        return spawn;
    }

    public void ResponseMove(ExtendedEventArgs eventArgs)
    {
        
        ResponseMoveEventArgs argTag = eventArgs as ResponseMoveEventArgs;

        foreach (GameObject eachPlayer in players)
        {
            if(eachPlayer.tag == argTag.clientTag.ToString())
            {
                // Previous player position
                Transform previous = eachPlayer.transform;

               // Lerp for smoother player movement from the server.
                eachPlayer.transform.position = Vector3.Lerp(previous.position, 
                                                eachPlayer.transform.position = new Vector3(argTag.posX, argTag.posY, argTag.posZ), 
                                                Time.deltaTime * 12);
            }
        }

        Debug.Log("Call back for moving.");
       
    }

    public void RequestReady()
    {
        player = players[0];
        int readyPlayer = int.Parse(player.tag);
        RequestReady ready = new RequestReady();
        ready.send(readyPlayer);
        cManager.send(ready);
        Debug.Log("Sent ready request");
    }

    public void ResponseReady(ExtendedEventArgs eventArgs)
    {
        ResponseReadyEventArgs args = eventArgs as ResponseReadyEventArgs;
        // player[0] represents the the current client
        player = players[0];
        // Ready screen 
        GameObject readyScreen = player.transform.GetChild(1).gameObject;

        if (args.readyPlayer == 1)
        {
            Debug.Log("Activating player 1 ready button");
            readyScreen.transform.GetChild(6).gameObject.GetComponent<Toggle>().isOn = true;
            player1Ready = true;
            // If both players ready then make start button interactive for player 1.
        }
        else if(args.readyPlayer == 2)
        {
            Debug.Log("Activating player 2 ready button");
            readyScreen.transform.GetChild(7).gameObject.GetComponent<Toggle>().isOn = true;
            player2Ready = true;
        }

        if (player1Ready == true && player2Ready == true)
        {
            readyScreen.transform.GetChild(3).gameObject.GetComponent<Button>().interactable = true;
        }

    }

    public void RequestUnready()
    {
        player = players[0];
        int unreadyPlayer = int.Parse(player.tag);
        RequestUnready unready = new RequestUnready();
        unready.send(unreadyPlayer);
        cManager.send(unready);
        Debug.Log("Sent unready request");
    }

    public void ResponseUnready(ExtendedEventArgs eventArgs)
    {
        ResponseUnreadyEventArgs args = eventArgs as ResponseUnreadyEventArgs;
        // player[0] represents the the current client
        player = players[0];
        // Ready screen 
        GameObject readyScreen = player.transform.GetChild(1).gameObject;

        if (args.unreadyPlayer == 1)
        {
            Debug.Log("Deactivating player 1 ready button");
            readyScreen.transform.GetChild(6).gameObject.GetComponent<Toggle>().isOn = false;
            player1Ready = false;
            
        }
        else if (args.unreadyPlayer == 2)
        {
            Debug.Log("Deactivating player 2 ready button");
            readyScreen.transform.GetChild(7).gameObject.GetComponent<Toggle>().isOn = false;
            player2Ready = false;
        }

        if (player1Ready == false || player2Ready == false)
        {
            readyScreen.transform.GetChild(3).gameObject.GetComponent<Button>().interactable = false;
        }

    }

    public void RequestLight(string lightColor)
    {
        RequestLight light = new RequestLight();
        light.send(lightColor);
        cManager.send(light);
        Debug.Log("Sent light color request: " + lightColor);
    }

    // Turn on and off lights/wall mesh renderers
    public void ResponseLight(ExtendedEventArgs eventArgs)
    {
        ResponseLightEventArgs args = eventArgs as ResponseLightEventArgs;
        GameObject lightTrigger = GameObject.FindGameObjectWithTag(args.light);
        lightTrigger.GetComponent<ActivateLight>().source.GetComponent<AudioSource>().Play();
        // Grab all lights to render from the game object
        EnableLight[] light = lightTrigger.GetComponent<ActivateLight>().lights;
        // Grab all walls to render from the game object
        EnableRender[] wall = lightTrigger.GetComponent<ActivateRender>().rend;

        // Turn on all the lights for this color
        for(int i = 0; i < light.Length; i++)
        {
            light[i].myLight.enabled = !light[i].myLight.enabled;
        }
        // Flip walls to be rendered for this color
        for (int i = 0; i < wall.Length; i++)
        {
            wall[i].renderObject.enabled = !wall[i].renderObject.enabled;
        }
    }

    public void RequestStart ()
    {
        player = players[0];
        RequestStart start = new RequestStart();
        start.send(1);
        cManager.send(start);
        Debug.Log("Sent start request");
    }

    public void ResponseStart(ExtendedEventArgs eventArgs)
    {
        // Used for movement to to begin for both players. 
        // if eventargs returns 1
        player = players[0];
        GameObject readyScreen = player.transform.GetChild(1).gameObject;
        GameObject playerObject = player.transform.GetChild(0).gameObject;
        playerObject.GetComponent<StartPlayerComponents>().gameStarted();
        readyScreen.GetComponent<Animation>().Play();
        Debug.Log("Players Activated");
    }

    public void RequestP2Correct(int value)
    {
        RequestP2Correct trigger = new RequestP2Correct();
        trigger.send(value);
        cManager.send(trigger);
        Debug.Log("Puzzle 2 trigger value request: " + value);
    }

    public void ResponseP2Correct(ExtendedEventArgs eventArgs)
    {
        ResponseP2CorrectEventArgs args = eventArgs as ResponseP2CorrectEventArgs;
        Debug.Log("Value is: " + args.trigger);
        if(args.trigger == 1)
        {
            GameObject trigger = GameObject.FindGameObjectWithTag("Puzzle2");
            // Moves podium for puzzle 2 in player 1 room
            trigger.GetComponent<Interact_Correct>().slideStay.tileStepped = true;
            EnableRender[] wall = trigger.GetComponent<ActivateRender>().rend;
            trigger.GetComponent<Interact_Correct>().ePressed = true;

            // Flip walls to be rendered for pulling the correct lever trigger
            for (int i = 0; i < wall.Length; i++)
            {
                wall[i].renderObject.enabled = !wall[i].renderObject.enabled;
            }

        } else if(args.trigger == 2)
        {
            // Open both walls to continue to puzzle 3 for both players
            GameObject trigger = GameObject.FindGameObjectWithTag("Puzzle2Finish");
            Interact_Correct[] puzzle2Walls = trigger.GetComponents<Interact_Correct>();

            for(int i = 0; i < puzzle2Walls.Length; i++)
            {
                puzzle2Walls[i].ePressed = true;
                puzzle2Walls[i].slideStay.tileStepped = true;
            }
        }
    }

    public void RequestP2Incorrect(int value)
    {
        RequestP2Incorrect trigger = new RequestP2Incorrect();
        trigger.send(value);
        cManager.send(trigger);
        Debug.Log("Puzzle 2 INCORRECT value request: " + value);
    }

    public void ResponseP2Incorrect(ExtendedEventArgs eventArgs)
    {
        ResponseP2IncorrectEventArgs args = eventArgs as ResponseP2IncorrectEventArgs;
        Debug.Log("INCORRECT TRIGGER IS: " + args.trigger);
        GameObject trigger = GameObject.FindGameObjectWithTag(args.trigger.ToString());
        Interact_Incorrect_P2 deathWalls = trigger.GetComponent<Interact_Incorrect_P2>();
        for(int i = 0; i < deathWalls.moveWall.Length; i++)
        {
            deathWalls.ePressed = true;
            deathWalls.moveWall[i].tileStepped = true;
        }

    }

    public void RequestGetScores()
    {
        RequestTopScore requestTopScore = new RequestTopScore();
        requestTopScore.send();
        cManager.send(requestTopScore);
        Debug.Log("Getting high scores");
    }

    public void ResponseTopScore(ExtendedEventArgs eventArgs)
    {
        Debug.Log("Callback for MessageReceived");
        ResponseTopScoreEventArgs args = eventArgs as ResponseTopScoreEventArgs;
        //  GameObject readyScreen = player.transform.GetChild(1).gameObject;
        Debug.Log("I am here in CountdownTimer.cs Script");
        string teamName = args.teamName;
        string teamTime = args.time;
        //countDownText.text = teamName + teamTime + " \n";
        string[] teams = teamName.Split(',');
        string[] timer = teamTime.Split(',');
        countDownText.text = "";
        countDownTeamName.text = "";
        for (int i = 0; i < teams.Length; i++)
        {
            int count = i + 1;
            Debug.Log("Team: " + countDownText.text);
            int seconds = (int.Parse(timer[i]) % 60);
            int minutes = (int.Parse(timer[i]) / 60) % 60;
            int hours = (int.Parse(timer[i]) / 3600) % 24;
            string timeString = string.Format("{0:0}:{1:00}:{2:00 }", hours, minutes, seconds);
            countDownTeamName.text = string.Format(countDownTeamName.text + count + ".   " + teams[i] + "\n");
            countDownText.text = string.Format(countDownText.text + timeString + "\n");

        }
    }


    public IEnumerator RequestHeartbeat(float time) {

        Debug.Log("In Coroutine");
		ConnectionManager cManager = gameObject.GetComponent<ConnectionManager>();

		
			RequestHeartbeat request = new RequestHeartbeat();
			request.send();
		
			cManager.send(request);

        yield return new WaitForSeconds(time);
        StartCoroutine(RequestHeartbeat(1f));
	}

    /*Chat*/
    public void SendMessagetoChat(String text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);
        messageList.Add(newMessage);
        RequestChat requestChat = new RequestChat();
        // Check first player added to the list because this is the real client.
        player = players[0];
        int readyPlayer = int.Parse(player.tag);
        if (player.tag == "1")
        {
            requestChat.send(1, newMessage.text);
        }else if(player.tag == "2")
        {
            requestChat.send(2, newMessage.text);
        }
        
        cManager.send(requestChat);
        //cManager.send(ChatProtocol.Prepare(1, newMessage.text));
    }

    public void ResponseChat(ExtendedEventArgs eventArgs)
    {
        Debug.Log("Callback for MessageReceived");
        ResponseChatEventArgs args = eventArgs as ResponseChatEventArgs;
        //  GameObject readyScreen = player.transform.GetChild(1).gameObject;
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();

        newMessage.text = args.message;
        Debug.Log("IN GameCHatManager: " + newMessage.text);
        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        //newMessage.textObject.color = MessageTypeColor(Message.MessageType.playerMessage);

        messageList.Add(newMessage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;
        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }
        return color;
    }

    [System.Serializable]
    public class Message
    {
        public string text;
        public Text textObject;
        public MessageType messageType;

        public enum MessageType
        {
            playerMessage,
            info,
            //lootInfo
        }

    }
}
