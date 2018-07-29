using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This enum stores all possible kinds of Coversituations
/// </summary>
public enum CoverType
{
    /// <summary>
    /// stands in the open field
    /// </summary>
    None = 0,
    /// <summary>
    /// Low Wall, Fence, fallen Tree,...
    /// </summary>
    Partial = 1,
    /// <summary>
    /// Wall, normal Tree
    /// </summary>
    Full = 2

}