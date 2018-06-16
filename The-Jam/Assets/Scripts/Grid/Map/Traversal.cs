using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this contains the data of a single traversal to another <see cref="Tile"/>
/// </summary>
public class Traversal  {

    public TraversalType Type;
    public Tile TileFrom;
    public Tile TileTo;

    public int Cost;

    public Traversal(TraversalType type, Tile tileFrom, Tile tileTo, int cost = 1)
    {
        Type = type;
        TileFrom = tileFrom;
        TileTo = tileTo;
        Cost = cost;
    }
}
