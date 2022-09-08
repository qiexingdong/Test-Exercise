using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHelper
{
    public static Transform GetChild(Transform far, string str)
    {
        Transform childTF = far.Find(str);
        if (childTF != null)
            return childTF;
        for (int i = 0; i < far.childCount; i++)
        {
            childTF = GetChild(far.GetChild(i), str);
            if (childTF != null)
                return childTF;
        }
        return null;
    }
}
