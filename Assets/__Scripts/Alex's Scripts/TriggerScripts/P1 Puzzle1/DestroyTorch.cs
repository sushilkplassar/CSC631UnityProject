using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTorch : MonoBehaviour
{
    public FindTorch spotlights;

    public bool inZone = false;

    public int x1 = 0;

    public void destroyTorch()
    {
        if (x1 == 0)
        {
            Destroy(spotlights.torch1);
            Destroy(spotlights.torch2);
            x1++;
        } else if (x1 == 1)
        {
            Destroy(spotlights.torch3);
            Destroy(spotlights.torch4);
            x1++;
        } else {
            Destroy(spotlights.torch5);
            Destroy(spotlights.torch6);
        }
    }
}
