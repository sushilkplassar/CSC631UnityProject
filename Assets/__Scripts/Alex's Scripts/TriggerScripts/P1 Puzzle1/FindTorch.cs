using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTorch : MonoBehaviour
{
    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;
    public GameObject torch4;
    public GameObject torch5;
    public GameObject torch6;
    // Start is called before the first frame update
    void Start()
    {
        torch1 = GameObject.Find("FP1");
        torch2 = GameObject.Find("FP2");
        torch3 = GameObject.Find("FP3");
        torch4 = GameObject.Find("FP4");
        torch5 = GameObject.Find("FP5");
        torch6 = GameObject.Find("FP6");
    }
}
