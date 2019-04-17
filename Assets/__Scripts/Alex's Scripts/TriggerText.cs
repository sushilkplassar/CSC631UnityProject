using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public FadeText fadeText;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "P1_Complete_Text")
        {   
            if (fadeText.stopText == 0){
                fadeText.stepOn = true;
                StartCoroutine(TurnTextOff());
            }
        }
    }

    IEnumerator TurnTextOff()
    {
        yield return new WaitForSeconds(2f);
        fadeText.stepOff = true;
        fadeText.stepOn = false;
        fadeText.stopText = 1;
    }
}
