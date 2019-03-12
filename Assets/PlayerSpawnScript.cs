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
        // Checks to see if this is another player that doesn belong to the local player. 
        if (isLocalPlayer == false)
        {
            return;
        }
        // Instantiate(PlayerObjectPrefab);
        CmdSpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Command]
    void CmdSpawnPlayer()
    {
        GameObject player = Instantiate(PlayerObjectPrefab);
        NetworkServer.Spawn(player);
    }
}
