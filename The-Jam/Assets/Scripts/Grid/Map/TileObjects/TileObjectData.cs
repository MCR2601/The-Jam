using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class contains all the tileobject information for a specific Tile
/// </summary>
public class TileObjectData {

    public List<BaseTileObject> Objects = new List<BaseTileObject>();

    public Tile Location;


    public TileObjectData(Tile loc, params BaseTileObject[] objects)
    {
        Location = loc;
        Objects.AddRange(objects);
    }
    



}
