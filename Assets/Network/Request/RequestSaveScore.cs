using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSaveScore : NetworkRequest
{

    public RequestSaveScore()
    {
        request_id = Constants.CMSG_SAVESCORE;
    }

    public void send(int playerId, int time)
    {
        Debug.Log("I am in ReqChat");
        packet = new GamePacket(request_id);
        packet.addInt32(playerId);
        //packet.addString(time);
        packet.addInt32(time);
        Debug.Log("Sent time from ReqTimer Protocol: " + time);
    }
}
