using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private Rigidbody rb;

    void Start()
    {
        //to enable proper physical movement of an object
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseUp()
    {
        rb.useGravity = true;
    }

    void OnMouseDown()
    {
        // the point of where the mouse clicks an gameobject
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        // turns gravity off when moving an item around to avoid stutter effect
        rb.useGravity = false;

        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

        // move object based on cursor
        rb.MovePosition(cursorPosition);
    }
}
