using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class ResponseTimeEventArgs : ExtendedEventArgs
{
    //public short status { get; set; }
    public String time { get; set; }
    public String playerID { get; set; }

    public ResponseTimeEventArgs()
    {
        event_id = Constants.SMSG_TIMER;
    }
}

public class ResponseTopScore : NetworkResponse
{

    private String playerID;
    private String time;

    public override void parse()
    {
        playerID = DataReader.ReadString(dataStream);
        time = DataReader.ReadString(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseTimeEventArgs args = null;
        args = new ResponseTimeEventArgs();
        args.playerID = playerID;
        args.time = time;
        Debug.Log("PlayerID current: " + playerID);
        Debug.Log("TIme Message: " + time);
        return args;
    }
}
