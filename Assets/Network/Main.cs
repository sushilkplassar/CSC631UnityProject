using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
    ConnectionManager cManager;
    MessageQueue msgQueue;

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
        Debug.Log("Successfully created and joined room.");
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
