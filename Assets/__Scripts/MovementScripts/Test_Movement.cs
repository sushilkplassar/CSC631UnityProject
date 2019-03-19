using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Movement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveForwardAndBack = Input.GetAxis("Vertical") * moveSpeed; // forward and backward movements is Z axis
        float moveSideToSide = Input.GetAxis("Horizontal") * moveSpeed; // Moving side to side is X axis
    }
}
