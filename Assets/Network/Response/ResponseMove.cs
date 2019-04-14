using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class ResponseMoveEventArgs : ExtendedEventArgs
{
    public int clientTag { get; set; }
    public float posX { get; set; }
    public float posZ { get; set; }
    
    public ResponseMoveEventArgs()
    {
        event_id = Constants.SMSG_MOVE;
    }
}

public class ResponseMove : NetworkResponse
{
    
    private float posX;
    private float posZ;
    private int clientTag;

    // May not need to implement?
    public ResponseMove()
    {
    }

    public override void parse()
    {
        clientTag = DataReader.ReadInt(dataStream);
        posX = DataReader.ReadFloat(dataStream);
        posZ = DataReader.ReadFloat(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseMoveEventArgs args = null;
        args = new ResponseMoveEventArgs();
        // Player position
        args.clientTag = clientTag;
        args.posX = posX;
        args.posZ = posZ;
        Debug.Log("Player moved to pos X: " + posX + " and pos Z: " + posZ);
        return args;
    }
}
