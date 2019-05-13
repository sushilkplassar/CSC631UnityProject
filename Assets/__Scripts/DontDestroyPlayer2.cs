using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class DontDestroyPlayer2 : MonoBehaviour
{
    void Awake()
    {
        GameObject[] player1 = GameObject.FindGameObjectsWithTag("2");

        if (player1.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("MultiplayerIntegration");
        }
    }
}
