using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Map  {

    const int RegionHeigh = 3;
    const int RegionWidth = 5;
    const int RegionLength = 5;
    
    public static Tile[,,] map;
    
    static Map()
    {
        map = new Tile[5, 5, 3];
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                map[x, y, 0] = new Tile(new SimpleCords(x, y, 0)) { Passable = true,Empty=false};
            }
        }
        map[1, 1, 1] = new Tile(new SimpleCords(1, 1, 1));
        map[1, 1, 2] = new Tile(new SimpleCords(1, 1, 2));
        map[1, 2, 1] = new Tile(new SimpleCords(1, 2, 1)) { Passable=false};

    }

    public static void Spawn()
    {
        foreach (Tile item in map)
        {
            if (item != null)
            {
                item.SpawnObject();
            }
        }
        UpdateCover();
        UpdateObjects();
    }

    public static void UpdateCover()
    {
        foreach (Tile item in map)
        {
            if (item!=null)
            {
                foreach (var side in item.Cover.GetAsDictionary())
                {
                    item.Cover[side.Key] = CheckCover(item, side.Key);
                }
                Debug.Log(item.Cover.CoverValue());
            }
        }
    }

    public static void UpdateTraversals()
    {

    }

    public static void UpdateObjects()
    {
        foreach (Tile item in map)
        {
            if (item != null)
            {

                if (item.Cover.CoverValue() > 0)
                {
                    if (item.Cover.CoverValue()>1)
                    {
                        Debug.Log("There should be a colorchange");
                        item.myObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                    }
                    else
                    {
                        Debug.Log("There should be a colorchange");
                        item.myObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    
                }
                else
                {
                    Renderer mr = item.myObject.GetComponent<Renderer>();
                    mr.material.color = Color.white;
                }


            }
        }
    }

    public static Tile GetTileWithCords(SimpleCords cords)
    {
        try
        {
            return map[cords.x, cords.y, cords.z];
        }
        catch (System.IndexOutOfRangeException)
        {
            return null;
        }       
    }

    private static CoverType CheckCover(Tile origin, Direction dir)
    {
        CoverType type = CoverType.None;
        if (origin.Passable)
        {
            SimpleCords location = new SimpleCords(origin.position);
            switch (dir)
            {
                case Direction.North:
                    location.Offset(0, 1, 0);
                    break;
                case Direction.East:
                    location.Offset(1, 0, 0);
                    break;
                case Direction.South:
                    location.Offset(0, -1, 0);
                    break;
                case Direction.West:
                    location.Offset(-1, 0, 0);
                    break;
                default:
                    break;
            }
            Tile workTile = GetTileWithCords(location.Offset(0, 0, 1));
            if (workTile!=null && !workTile.Empty)
            {
                type = CoverType.Partial;
            }
            workTile = GetTileWithCords(location.Offset(0, 0, 1));
            if (workTile != null && !workTile.Empty)
            {
                type = CoverType.Full;
            }
        }
        return type;
    }

}
