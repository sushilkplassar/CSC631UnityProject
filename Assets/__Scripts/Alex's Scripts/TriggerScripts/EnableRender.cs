using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRender : MonoBehaviour
{
    public Renderer renderObject;

    void Start()
    {
        renderObject = GetComponent<Renderer>();
        //renderObject.enabled = true;
    }
}
