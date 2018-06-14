using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class contains all the information about a connection between a Tile
/// It is used for pathing
/// </summary>
public class TraversalData {

    public Traversal North;
    public Traversal East;
    public Traversal South;
    public Traversal West;

    public Tile Location;

    public TraversalData(Traversal north, Traversal east, Traversal south, Traversal west, Tile location)
    {
        North = north;
        East = east;
        South = south;
        West = west;
        Location = location;
    }

    public TraversalData(Tile location)
    {   
        Location = location;
        North = new Traversal(TraversalType.None, Location, null);
        East = new Traversal(TraversalType.None, Location, null);
        South = new Traversal(TraversalType.None, location, null);
        West = new Traversal(TraversalType.None, Location, null);
    }

    public Traversal this[Direction i]
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
                    return new Traversal(TraversalType.Walking,null,null);
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
