using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile {
    

    public SimpleCords position;

    public CoverData Cover;

    public bool Passable;

    public bool Empty;    

    public Tile()
    {
        
    }

    public Tile(SimpleCords position)
    {
        this.position = position;
        Passable = true;
        Empty = false;
    }


}
