using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestTopScore : NetworkRequest
{

    public RequestTopScore()
    {
        request_id = Constants.CMSG_TIMER;
    }

    public void send(int playerId, int time)
    {
        Debug.Log("I am in ReqTopScore");
        packet = new GamePacket(request_id);
        //packet.addInt32(playerId);
        //packet.addString(time);
        //packet.addInt32(time);
        Debug.Log("Sent time from ReqTopScore Protocol: " + time);
    }
}
