using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestLight : NetworkRequest
{
    // Start is called before the first frame update
    public RequestLight()
    {
        request_id = Constants.CMSG_LIGHT;
    }

    public void send(string light)
    {
        packet = new GamePacket(request_id);
        // Send light color to turn on
        packet.addString(light);
    }
}