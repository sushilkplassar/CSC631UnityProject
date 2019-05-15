using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class ResponseTopScoreEventArgs : ExtendedEventArgs
{
    //public short status { get; set; }
    public String time { get; set; }
    public String playerID { get; set; }

    public ResponseTopScoreEventArgs()
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
        ResponseTopScoreEventArgs args = null;
        args = new ResponseTopScoreEventArgs();
        args.playerID = playerID;
        args.time = time;
        Debug.Log("PlayerID received from DB: " + playerID);
        Debug.Log("TIme received from DB: " + time);
        return args;
    }
}
