using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    private Camera playerCam;

	void Start () {
		playerCam = GetComponent<Camera> ();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
