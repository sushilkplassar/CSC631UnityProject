using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseP2CorrectEventArgs : ExtendedEventArgs
{
    public int trigger { get; set; }

    public ResponseP2CorrectEventArgs()
    {
        event_id = Constants.SMSG_P2CORRECT;
    }
}

public class ResponseP2Correct : NetworkResponse
{
    private int trigger;

    // May not need to implement?
    public ResponseP2Correct()
    {
    }

    public override void parse()
    {
        trigger = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseP2CorrectEventArgs args = null;
        args = new ResponseP2CorrectEventArgs();
        args.trigger = trigger;
        Debug.Log("Puzzle 2 trigger is: " + trigger);
        return args;
    }
}
