using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestReady : NetworkRequest
{
    // Start is called before the first frame update
    public RequestReady()
    {
        request_id = Constants.CMSG_READY;
    }

    public void send()
    {
        packet = new GamePacket(request_id);
        // Send 1 to indicate that player is ready
        packet.addInt32(1);
        //packet.addInt32(id);
        //packet.addString(password);
    }
}
