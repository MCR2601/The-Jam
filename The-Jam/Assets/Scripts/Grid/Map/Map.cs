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
        map = new Tile[5, 5, 1];
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                map[x, y, 0] = new Tile(new SimpleCords(x, y, 0));
            }
        }
    }


}
