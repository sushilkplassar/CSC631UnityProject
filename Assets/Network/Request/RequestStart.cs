using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestStart : NetworkRequest
{
    // Start is called before the first frame update
    public RequestStart()
    {
        request_id = Constants.CMSG_START;
    }

    public void send(int start)
    {
        packet = new GamePacket(request_id);
        // Send 1 to indicate that player is ready
        packet.addInt32(start);
        //packet.addInt32(id);
        //packet.addString(password);
    }
}
