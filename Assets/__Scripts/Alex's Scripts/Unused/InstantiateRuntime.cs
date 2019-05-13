using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRuntime : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, new Vector3(21.95f,0.922f, -19.408f), Quaternion.identity);
    }
}
