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

        map[0, 2, 0] = new Tile(new SimpleCords(0, 2, 0)) { Passable = false};
        map[0, 2, 1] = new Tile(new SimpleCords(0, 2, 1)) { Passable = false };
        map[0, 2, 2] = new Tile(new SimpleCords(0, 2, 2)) { Passable = true };

        map[1, 2, 0] = new Tile(new SimpleCords(1, 2, 0)) { Passable = false};
        map[1, 2, 1] = new Tile(new SimpleCords(1, 2, 1)) { Passable = true };



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
        UpdateTraversals();
        UpdateObjects();

        foreach (Tile item in map)
        {
            if (item!=null)
            {
                Debug.Log("gonna do the lines now");
                item.Traversals.SpawnDebugLines();
            }
        }

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
        // currently you can only go up 1 layer and move straight

        foreach (var item in map)
        {
            if (item!= null && item.Passable)
            {
                foreach (var side in item.Traversals.GetAsDictionary())
                {
                    Tile neighbour = GetTraversabalTile(item, side.Key);
                    if (neighbour != null)
                    {
                        int difference = neighbour.position.h - item.position.h;
                        Debug.Log("Difference: " + difference);
                        if (difference == 0)
                        {
                            item.Traversals[side.Key] = new Traversal(TraversalType.Walking, item, neighbour);
                        }
                        else
                        {
                            if (difference == 1)
                            {
                                item.Traversals[side.Key] = new Traversal(TraversalType.ClimbUp,item,neighbour);
                            }
                            else
                            {
                                if (difference == -1)
                                {
                                    item.Traversals[side.Key] = new Traversal(TraversalType.ClimbDown, item, neighbour);
                                }
                                else
                                {
                                    if (difference < -1)
                                    {
                                        item.Traversals[side.Key] = new Traversal(TraversalType.DropDown, item, neighbour);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("no neighbour");
                    }
                }
                

            }

        }





    }

    public static void UpdateExistancePassability()
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
            return map[cords.x, cords.y, cords.h];
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

    public static Tile GetTraversabalTile(Tile tile, Direction dir)
    {
        SimpleCords OtherCord = tile.position.GetInDirection(dir, 1).GetAbove();
        
        for (int h = OtherCord.h; h >= 0 ; h--)
        {

            Tile tmp = GetTileWithCords(new SimpleCords(OtherCord.x,OtherCord.y,h));
            if (tmp != null && tmp.Empty == false)
            {
                if (tmp.Passable == true)
                {
                    return tmp;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Debug.LogError("We didnt find a tile");
            }
        }
        return null;
    }

}
