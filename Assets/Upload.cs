using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEditor;

public class Upload : MonoBehaviour
{

    private GameObject mainObject;
    // Window Properties
    private float width = 280;
    private float height = 120;
    // Other

    private string teamName = "";
    private string password = "";
    private Rect windowRect;
    private bool isHidden;
    private MessageQueue msgQueue;
    private ConnectionManager cManager;

    void Awake()
    {
        mainObject = GameObject.FindGameObjectWithTag("heartbeat");
        cManager = mainObject.GetComponent<ConnectionManager>();
        msgQueue = mainObject.GetComponent<MessageQueue>();
        //msgQueue.AddCallback(Constants.SMSG_LOGIN, ResponseLogin);
        //msgQueue.AddCallback(Constants.SMSG_TEST, responseTest);
    }

    // Use this for initialization
    void Start()
    {

    }

    void OnGUI()
    {
        // Background
       // GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
        // Client Version Label
        //GUI.Label(new Rect(Screen.width - 75, Screen.height - 30, 65, 20), "v" + Constants.CLIENT_VERSION + " Test");
        // Login Interface
        if (!isHidden)
        {
            windowRect = new Rect((Screen.width - width) / 2, Screen.height / 2 - height, width, height);
            windowRect = GUILayout.Window((int)Constants.GUI_ID.Team, windowRect, MakeWindow, "Enter Team Name");
            if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return)
            {
                Submit();
            }
        }
    }

    void MakeWindow(int id)
    {
        GUILayout.Label("Team Name");
        GUI.SetNextControlName("teamname_field");
        teamName = GUI.TextField(new Rect(10, 45, windowRect.width - 20, 25), teamName, 25);
        GUILayout.Space(50);
        if (GUI.Button(new Rect(windowRect.width / 2 - 50, 75, 100, 35), "Submit"))
        {
            Submit();
        }
    }

    public void Submit()
    {
        teamName = teamName.Trim();
        password = password.Trim();
        if (teamName.Length == 0)
        {
            Debug.Log("Team Name Required");
            GUI.FocusControl("teamname_field");
        }
        else
        {
            // Turn off upload window after first submit
            GameObject.FindGameObjectWithTag("TeamNameWindow").GetComponent<Upload>().enabled = false;
            GameObject.FindGameObjectWithTag("EndMenu").GetComponent<LobbyOptions>().submitted = true;
            GameObject.FindGameObjectWithTag("timeScreen").GetComponent<LobbyOptions>().submitted = true;
            cManager.send(saveScore(teamName));
            Debug.Log("Sent team name and time");
        }
    }

    public RequestSaveScore saveScore(string teamName)
    {
        
        RequestSaveScore request = new RequestSaveScore();
        GrabScore score = GameObject.FindGameObjectWithTag("Finish").GetComponent<GrabScore>();
        int time = (int)score.score;
        request.send(teamName, time);
        return request;
    }

    public void Show()
    {
        isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
