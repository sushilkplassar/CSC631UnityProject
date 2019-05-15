using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestTopScore : NetworkRequest
{

    public RequestTopScore()
    {
        request_id = Constants.CMSG_TIMER;
    }

    public void send()
    {
        Debug.Log("I am in ReqTopScore");
        packet = new GamePacket(request_id);
    }
}
