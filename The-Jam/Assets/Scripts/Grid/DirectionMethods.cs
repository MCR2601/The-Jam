using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionMethodes {

	public static void Invert (this Direction dir)
    {
        dir = (Direction)(((int)dir + 2) % 4);
    }
}
