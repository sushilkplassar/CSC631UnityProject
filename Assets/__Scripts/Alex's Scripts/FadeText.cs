using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    
    public bool stepOn = false;
    public bool stepOff = false;
    public int stopText = 0;
    
    void Update()
    {
        if (stepOn == true)
        {
            StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
        }

        if(stepOff == true)
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
        } 
    }
 
 
 
    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        stepOff = false;
    }
}
