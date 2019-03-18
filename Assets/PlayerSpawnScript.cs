using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpawnScript : NetworkBehaviour
{
    public GameObject PlayerObjectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // Checks to see if this is another player that doesn't belong to the local player. 
        if (isLocalPlayer == false)
        {
            return;
        }
       
        CmdSpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer == false)
        {
            return;
        }
        
    }

    [Command]
    void CmdSpawnPlayer()
    {
        GameObject player = Instantiate(PlayerObjectPrefab);

        // Turns off the camera for other players after they spawn in.
        if (isLocalPlayer == false)
        {
            // Camera is a child of the player object.
            player.GetComponentInChildren<Camera>().enabled = false;
        }
        NetworkServer.SpawnWithClientAuthority(player, connectionToClient);
    }
}
