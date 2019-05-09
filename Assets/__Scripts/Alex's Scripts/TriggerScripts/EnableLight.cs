using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLight : MonoBehaviour
{
    public Light myLight;
    
    
    public void Start ()
    {
        myLight = GetComponent<Light>();
    }
}
