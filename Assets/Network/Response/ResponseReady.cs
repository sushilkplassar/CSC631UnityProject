using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseReadyEventArgs : ExtendedEventArgs
{
    public int readyPlayer { get; set; }

    public ResponseReadyEventArgs()
    {
        event_id = Constants.SMSG_READY;
    }
}

public class ResponseReady : NetworkResponse
{
    private int readyPlayer;

    // May not need to implement?
    public ResponseReady()
    {
    }

    public override void parse()
    {
        readyPlayer = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseReadyEventArgs args = null;
        args = new ResponseReadyEventArgs();
        args.readyPlayer = readyPlayer;
        Debug.Log("Player is ready.");
        return args;
    }
}
