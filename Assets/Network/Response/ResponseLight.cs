using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseLightEventArgs : ExtendedEventArgs
{
    public string light { get; set; }

    public ResponseLightEventArgs()
    {
        event_id = Constants.SMSG_LIGHT;
    }
}

public class ResponseLight : NetworkResponse
{
    private string light;

    // May not need to implement?
    public ResponseLight()
    {
    }

    public override void parse()
    {
        light = DataReader.ReadString(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseLightEventArgs args = null;
        args = new ResponseLightEventArgs();
        args.light = light;
        Debug.Log("Light color is: " + light);
        return args;
    }
}
