using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils
{
    public static void SetCurrentTransform(Transform sourceTransform,Transform targetTransform,bool ignoreScale = true)
    {
        sourceTransform.position = targetTransform.position;
        sourceTransform.rotation = targetTransform.rotation;

        if(!ignoreScale)
        {
            sourceTransform.localScale = targetTransform.localScale;
        }
       
    }
}


