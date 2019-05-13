using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class DontDestroyHeartbeat : MonoBehaviour
{
    void Awake()
    {
        GameObject[] heartbeat = GameObject.FindGameObjectsWithTag("heartbeat");
        

        if (heartbeat.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    

}
