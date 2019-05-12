using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseP2TriggersEventArgs : ExtendedEventArgs
{
    public int trigger { get; set; }

    public ResponseP2TriggersEventArgs()
    {
        event_id = Constants.SMSG_P2TRIGGERS;
    }
}

public class ResponseP2Triggers : NetworkResponse
{
    private int trigger;

    // May not need to implement?
    public ResponseP2Triggers()
    {
    }

    public override void parse()
    {
        trigger = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseP2TriggersEventArgs args = null;
        args = new ResponseP2TriggersEventArgs();
        args.trigger = trigger;
        Debug.Log("Puzzle 2 trigger is: " + trigger);
        return args;
    }
}
