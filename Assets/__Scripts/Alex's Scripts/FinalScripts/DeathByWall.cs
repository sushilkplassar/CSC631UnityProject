using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class DeathByWall : MonoBehaviour
{
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Alex's Scene (P2 Puzzle)");
        }
    
    }
}
