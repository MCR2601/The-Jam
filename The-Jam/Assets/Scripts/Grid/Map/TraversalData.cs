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
    public Dictionary<Direction, Traversal> GetAsDictionary()
    {
        Dictionary<Direction, Traversal> dict = new Dictionary<Direction, Traversal>();
        if(North != null)dict.Add(Direction.North, North);
        if (East != null) dict.Add(Direction.East, East);
        if (South != null) dict.Add(Direction.South, South);
        if (West != null) dict.Add(Direction.West, West);
        return dict;
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

    public void SpawnDebugLines()
    {
        foreach (var item in GetAsDictionary())
        {
            if (item.Value.Type != TraversalType.None)
            {
                Debug.Log("Traversal Something");
                GameObject go = new GameObject();

                LineRenderer lr = go.AddComponent<LineRenderer>();

                lr.material = new Material(Shader.Find("Sprites/Default"));

                lr.startWidth = 0.3f;
                lr.endWidth = 0.05f;

                Color r = Color.red;
                r.a = 255;
                lr.startColor = r;

                Color w = Color.white;
                w.a = 255;
                lr.endColor = w;

                



                lr.SetPositions(new Vector3[] { item.Value.TileFrom.position.GetAbove(), item.Value.TileTo.position.GetAbove() });
            }
            else
            {
                Debug.Log("Traversal None");
            }
            
        }

    }



}
