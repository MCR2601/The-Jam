using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoverMethods  {

    public static void AddUp(this CoverType curr, CoverType otherCover)
    {
        curr = (CoverType)Mathf.Max((int)curr, (int)otherCover);
    }
}
