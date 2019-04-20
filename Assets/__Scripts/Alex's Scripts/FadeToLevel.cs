using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToLevel : MonoBehaviour
{
     public CanvasGroup canvasGroup;
     private float elapsedTime;
     private float fadeTime = 1f;
    
    void Update()
    {
        DoFadeOut();
    }

    IEnumerator DoFadeOut()
     {
         while(canvasGroup.alpha > 0)
         {
             elapsedTime += Time.deltaTime;
             canvasGroup.GetComponent<CanvasGroup>().alpha = Mathf.Clamp01(1.0f - (elapsedTime / fadeTime));
             yield return null;
         }
 
         yield return null;
     }
}


