using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class DontDestroyPlayer : MonoBehaviour
{   
    
    void Awake()
    {
        
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Alex's Scene (P2 Puzzle)");
        }
    }
}
