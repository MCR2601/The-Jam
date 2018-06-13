using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverData {

    public CoverType North;
    public CoverType East;
    public CoverType South;
    public CoverType West;

    public CoverData(CoverType n, CoverType e, CoverType s, CoverType w)
    {
        North = n;
        East = e;
        South = s;
        West = w;
    }
    /// <summary>
    /// returns a cover based on a Direction
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public CoverType this[Direction i]
    {
        get
        {
            switch (i)
            {
                case Direction.North:
                    return North;
                case Direction.East:
                    return East;
                case Direction.South:
                    return South;
                case Direction.West:
                    return West;
                default:
                    return CoverType.None;
            }
        }
        set
        {
            switch (i)
            {
                case Direction.North:
                    North = value;
                    break;
                case Direction.East:
                    East = value;
                    break;
                case Direction.South:
                    South = value;
                    break;
                case Direction.West:
                    West = value;
                    break;
                default:
                    break;
            }
        }
    }



}
