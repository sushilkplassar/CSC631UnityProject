using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    // Camera will act as like a hand to pick up objects.
    private Camera hand;
    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // When player clicks left button, try to pick up object.
        if(Input.GetMouseButtonDown(0))
        {
            // Point is pixel of what you are trying to pick up. 
            Vector3 point = new Vector3(hand.pixelWidth / 2, hand.pixelHeight / 2, 0);
            Ray ray = hand.ScreenPointToRay(point);
            RaycastHit objectGrabbed;
            if (Physics.Raycast(ray, out objectGrabbed))
            {
                Debug.Log("Object coordinates to be grabbed " + objectGrabbed.point);
            }

        }
        
    }
}
