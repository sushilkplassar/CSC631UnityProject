using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestChat : NetworkRequest
{

    public RequestChat()
    {
        request_id = Constants.CMSG_CHAT;
    }

    public void send(int playerId, string message)
    {
        Debug.Log("I am in ReqChat");
        packet = new GamePacket(request_id);
        packet.addInt32(playerId);
        packet.addString(message);
        Debug.Log("Sent playerid: " + playerId + " and message: " + message);
    }
}
