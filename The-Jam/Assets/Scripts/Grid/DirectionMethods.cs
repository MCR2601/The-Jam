using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionMethodes {

    /// <summary>
    /// returns an inverted direction
    /// </summary>
    /// <param name="dir">the direction</param>
    /// <returns>inverted direction</returns>
	public static Direction Invert (this Direction dir)
    {
        return (Direction)(((int)dir + 2) % 4);
    }
}
