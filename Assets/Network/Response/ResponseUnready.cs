using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseUnreadyEventArgs : ExtendedEventArgs
{
    public int unreadyPlayer { get; set; }

    public ResponseUnreadyEventArgs()
    {
        event_id = Constants.SMSG_UNREADY;
    }
}

public class ResponseUnready : NetworkResponse
{
    private int unreadyPlayer;

    // May not need to implement?
    public ResponseUnready()
    {
    }

    public override void parse()
    {
        unreadyPlayer = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseUnreadyEventArgs args = null;
        args = new ResponseUnreadyEventArgs();
        args.unreadyPlayer = unreadyPlayer;
        Debug.Log("Player is unready.");
        return args;
    }
}
