using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectBox {

    static Dictionary<string, BaseTileObject> Box = new Dictionary<string, BaseTileObject>();

    static ObjectBox()
    {
        BaseTileObject partialCover;
        partialCover = new BaseTileObject("CoverPartial", "CoverPartial", new SimpleCords(0, 0, 0), true, true, CoverType.Partial, TraversalType.None);
        BaseTileObject lowWall;
        lowWall = new BaseTileObject("WallLow", "WallLow", new SimpleCords(0, 0, 0), true, false, CoverType.Partial, TraversalType.Vault);
        BaseTileObject highWall;
        highWall = new BaseTileObject("WallHigh", "WallHigh", new Vector3(0, 0.5f, 0), true, false, CoverType.Full, TraversalType.None);
        AddToBox(partialCover);
        AddToBox(lowWall);
        AddToBox(highWall);
    }

    public static void AddToBox(BaseTileObject obj)
    {
        Box.Add(obj.ObjectName, obj);
    }

    public static BaseTileObject GetObjectByName(string name)
    {
        if (Box.ContainsKey(name))
        {
            return Box[name].Clone();
        }
        Debug.LogError("Wanted to access a not existing TileObject");
        return null;
    }
    
}
