using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestP2Triggers : NetworkRequest
{
    // Start is called before the first frame update
    public RequestP2Triggers()
    {
        request_id = Constants.CMSG_P2TRIGGERS;
    }

    public void send(int trigger)
    {
        packet = new GamePacket(request_id);
        // Send 1 for correct, 0 if wrong.
        packet.addInt32(trigger);
    }
}