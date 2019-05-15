using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    public float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
    }
    
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 50, 20), "" + timer.ToString("0"));
    }
}