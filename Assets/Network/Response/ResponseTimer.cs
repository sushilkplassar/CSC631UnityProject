using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class ResponseTimeEventArgs : ExtendedEventArgs
{
    //public short status { get; set; }
    public String message { get; set; }
    public String playerID { get; set; }

    public ResponseTimeEventArgs()
    {
        event_id = Constants.SMSG_TIMER;
    }
}

public class ResponseTimer : NetworkResponse
{

    private String playerID;
    private String message;

    public override void parse()
    {
        playerID = DataReader.ReadString(dataStream);
        message = DataReader.ReadString(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseTimeEventArgs args = null;
        args = new ResponseTimeEventArgs();
        args.playerID = playerID;
        args.message = message;
        Debug.Log("PlayerID current: " + playerID);
        Debug.Log("TIme Message: " + message);
        return args;
    }
}
