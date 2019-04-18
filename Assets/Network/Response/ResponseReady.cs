using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseReadyEventArgs : ExtendedEventArgs
{
    public int ready { get; set; }

    public ResponseReadyEventArgs()
    {
        event_id = Constants.SMSG_READY;
    }
}

public class ResponseReady : NetworkResponse
{
    private int ready;

    // May not need to implement?
    public ResponseReady()
    {
    }

    public override void parse()
    {
        ready = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseReadyEventArgs args = null;
        args = new ResponseReadyEventArgs();
        // Player position
        args.ready = ready;
        Debug.Log("Player is ready.");
        return args;
    }
}
