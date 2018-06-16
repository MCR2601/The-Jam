using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Types that can happen when going to other tile
/// </summary>
public enum TraversalType
{
    /// <summary>
    /// Not traversable
    /// </summary>
    None,
    /// <summary>
    /// Normal flat movement
    /// </summary>
    Walking,
    /// <summary>
    /// over a fence or log
    /// </summary>
    Vault,
    /// <summary>
    /// climb up a half high ledge
    /// </summary>
    ClimbUp,
    /// <summary>
    /// climb down a half high ledge
    /// </summary>
    ClimbDown,
    /// <summary>
    /// breach through a door
    /// </summary>
    Door,
    /// <summary>
    /// breach through a window
    /// </summary>
    Window,
    /// <summary>
    /// climb up a ladder
    /// </summary>
    LadderUp,
    /// <summary>
    /// climb down a ladder
    /// </summary>
    LadderDown,
    /// <summary>
    /// Drop down from a higher position
    /// </summary>
    DropDown
}
