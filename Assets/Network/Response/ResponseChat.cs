using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class ResponseChatEventArgs : ExtendedEventArgs
{
    //public short status { get; set; }
    public string message { get; set; }
    public int playerID { get; set; }

    public ResponseChatEventArgs()
    {
        event_id = Constants.SMSG_CHAT;
    }
}

public class ResponseChat : NetworkResponse
{

    private int playerID;
    private string message;

    public override void parse()
    {
        playerID = DataReader.ReadInt(dataStream);
        message = DataReader.ReadString(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseChatEventArgs args = null;
        args = new ResponseChatEventArgs();
        args.playerID = playerID;
        args.message = message;
        Debug.Log("PlayerID current: " + playerID);
        Debug.Log("Message: " + message);
        return args;
    }
}
