using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseP2IncorrectEventArgs : ExtendedEventArgs
{
    public int trigger { get; set; }

    public ResponseP2IncorrectEventArgs()
    {
        event_id = Constants.SMSG_P2INCORRECT;
    }
}

public class ResponseP2Incorrect : NetworkResponse
{
    private int trigger;

    // May not need to implement?
    public ResponseP2Incorrect()
    {
    }

    public override void parse()
    {
        trigger = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseP2IncorrectEventArgs args = null;
        args = new ResponseP2IncorrectEventArgs();
        args.trigger = trigger;
        Debug.Log("Puzzle 2 INCORRECT trigger is: " + trigger);
        return args;
    }
}
