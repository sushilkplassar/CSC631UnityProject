using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object has Character Controller attached
// Object has Object_Gravity script attached
public class PushObject : MonoBehaviour
{
    public float pushPower = 0.5F;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
          CharacterController con = hit.transform.GetComponent<CharacterController> ();

        if (con == null) {return;}
        if (hit.moveDirection.y < -0.3F) {return;}

        Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
        con.Move (pushDir * Time.deltaTime * pushPower);
    }

}
