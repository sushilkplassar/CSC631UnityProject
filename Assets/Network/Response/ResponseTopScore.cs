using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class ResponseTopScoreEventArgs : ExtendedEventArgs
{
    //public short status { get; set; }
    public String time { get; set; }
    public String teamName { get; set; }

    public ResponseTopScoreEventArgs()
    {
        event_id = Constants.SMSG_TIMER;
    }
}

public class ResponseTopScore : NetworkResponse
{

    private String teamName;
    private String time;

    public override void parse()
    {
        teamName = DataReader.ReadString(dataStream);
        time = DataReader.ReadString(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseTopScoreEventArgs args = null;
        args = new ResponseTopScoreEventArgs();
        args.teamName = teamName;
        args.time = time;
        Debug.Log("Team Name received from DB: " + teamName);
        Debug.Log("TIme received from DB: " + time);
        return args;
    }
}
