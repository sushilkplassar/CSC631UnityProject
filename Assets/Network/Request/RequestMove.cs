﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestMove : NetworkRequest
{

    public RequestMove()
    {
        request_id = Constants.CMSG_MOVE;
    }

    public void send(float posX, float posZ)
    {
        // Send ints for now, java server cant detect floats sent.
        int posx = (int)posX;
        int posz = (int)posZ;
        Debug.Log("X position: Integer of float: " + posx + " Actual float: " + posX);
        Debug.Log("Z position: Integer of float: " + posz + " Actual float: " + posZ);
        packet = new GamePacket(request_id);
        // Player position
        packet.addInt32(posx);
        packet.addInt32(posz);
        //packet.addFloat32(posX);
        //packet.addFloat32(posZ);
        Debug.Log("Sent posX: " + posx + " and posZ: " + posz);
    }
}