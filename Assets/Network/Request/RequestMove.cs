using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestMove : NetworkRequest
{

    public RequestMove()
    {
        request_id = Constants.CMSG_MOVE;
    }

    public void send(float posX, float posY, float posZ)
    {
        // Send ints for now, java server cant detect floats sent.
        int posx = (int)posX;
        int posy = (int)posY;
        int posz = (int)posZ;
        packet = new GamePacket(request_id);
        // Player position
        packet.addInt32(posx);
        packet.addInt32(posy);
        packet.addInt32(posz);

    }
}
