using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameChatManager : MonoBehaviour
{
    ConnectionManager cManager;
    MessageQueue msgQueue;
    public List<GameObject> players = new List<GameObject>();
    private GameObject player;

    public int maxMessages = 25;
    public string username;

    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public Color playerMessage, info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

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
        msgQueue.AddCallback(Constants.SMSG_CHAT, ResponseChat);
        Debug.Log("Callback called");

        Debug.Log("Starting Coroutine");
        StartCoroutine(RequestHeartbeat(1f));
    }

    private void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessagetoChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessagetoChat("You pressed the space bar", Message.MessageType.info);
                Debug.Log("Space");
            }
        }
    }

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
        requestChat.send(1, newMessage.text);
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

    //Heartbeat protocol
    public IEnumerator RequestHeartbeat(float time)
    {

        Debug.Log("In Coroutine");
        ConnectionManager cManager = gameObject.GetComponent<ConnectionManager>();


        RequestHeartbeat request = new RequestHeartbeat();
        request.send();

        cManager.send(request);

        yield return new WaitForSeconds(time);
        StartCoroutine(RequestHeartbeat(1f));
    }
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


