using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
    ConnectionManager cManager;
    MessageQueue msgQueue;
    List<GameObject> players = new List<GameObject>();
    private GameObject player;

    void Awake() {
        //DontDestroyOnLoad(gameObject);
        NetworkRequestTable.init();
        NetworkResponseTable.init();

        
        gameObject.AddComponent<MessageQueue>();
		gameObject.AddComponent<ConnectionManager>();
		
		
	}
	
	// Use this for initialization
	void Start () {

        
        cManager = gameObject.GetComponent<ConnectionManager>();
        msgQueue = gameObject.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_AUTH, ResponseCreate);
        //msgQueue.AddCallback(Constants.SMSG_PLAYERS, responsePlayers);
        //msgQueue.AddCallback(Constants.SMSG_TEST, responseTest);

        Debug.Log("Starting Coroutine");
		StartCoroutine(RequestHeartbeat(1f));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Function to be called after processing a message.
    // Function callbacks used to show what is received or what happens to the client
    // after the request is done processing from the connection manager. 
    public void ResponseCreate(ExtendedEventArgs eventArgs)
    {
        // if eventArgs.playertag == 1 or eventArgs.playertag == 2 to tell them to spawn in different areas
        player = spawnHere(eventArgs);

        players.Add(player);
        if (players.Count == 1)
        {  
            Debug.Log("Added first player in list.");
        }
        
        if(players.Count > 1)
        {
            Debug.Log("Adding subsequent players that join.");

            // Player Object is a child of the Player Spawn Game Object.
            GameObject playerObject = player.transform.GetChild(0).gameObject;
            // Turn off all children associated with the new player object that joins.
            for (int i = 0; i < playerObject.transform.childCount; i++)
            {
                // The rest of the children is within this player. 
                GameObject child = playerObject.transform.GetChild(i).gameObject;

                // Turning off children of player. 
                if (child != null)
                    child.SetActive(false);
            }
            // Turn off all movement and camera objects so that one input doesn't move both player objects.
            
            playerObject.GetComponent<FPMovement>().enabled = false;
            playerObject.GetComponent<CharacterController>().enabled = false;
            playerObject.GetComponent<MouseLook>().enabled = false;
           
        }
        Debug.Log("Successfully created player in callback function.");
    }

    // Spawn players in different areas of the room based on their tag.
    public GameObject spawnHere(ExtendedEventArgs eventArgs)
    {
        GameObject spawn = null;
        // if eventArgs.playertag == 1 or eventArgs.playertag == 2 to tell them to spawn in different areas
        ResponseCreateEventArgs argID = eventArgs as ResponseCreateEventArgs;
        if (argID.user_id == 1)
        {
            spawn = Instantiate(Resources.Load<GameObject>("Prefabs/Player1Spawn"));
            
        }
        if (argID.user_id == 2)
        {
            spawn = Instantiate(Resources.Load<GameObject>("Prefabs/Player2Spawn"));
        }
        return spawn;
    }

    public IEnumerator RequestHeartbeat(float time) {

        Debug.Log("In Coroutine");
		ConnectionManager cManager = gameObject.GetComponent<ConnectionManager>();

		
			RequestHeartbeat request = new RequestHeartbeat();
			request.send();
		
			cManager.send(request);

        yield return new WaitForSeconds(time);
        StartCoroutine(RequestHeartbeat(1f));
	}
}
