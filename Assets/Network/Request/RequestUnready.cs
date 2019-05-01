using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestUnready : NetworkRequest
{
    // Start is called before the first frame update
    public RequestUnready()
    {
        request_id = Constants.CMSG_UNREADY;
    }

    public void send(int playerNumber)
    {
        packet = new GamePacket(request_id);
        // Send 1 to indicate that player is ready
        packet.addInt32(playerNumber);
        //packet.addInt32(id);
        //packet.addString(password);
    }
}
