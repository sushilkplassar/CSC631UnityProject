using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseStartEventArgs : ExtendedEventArgs
{
    public int start { get; set; }

    public ResponseStartEventArgs()
    {
        event_id = Constants.SMSG_START;
    }
}

public class ResponseStart : NetworkResponse
{
    private int start;

    // May not need to implement?
    public ResponseStart()
    {
    }

    public override void parse()
    {
        start = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseStartEventArgs args = null;
        args = new ResponseStartEventArgs();
        args.start = start;
        Debug.Log("Starting the game.");
        return args;
    }
}
