using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Gravity : MonoBehaviour
{
    public float gravity = -9.8f;

	private CharacterController _charCont;
    // Start is called before the first frame update
    void Start()
    {
        _charCont = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3 (0, 0, 0);
        movement.y = gravity;
        movement *= Time.deltaTime;	
        movement = transform.TransformDirection(movement);
        _charCont.Move (movement);
    }
}
