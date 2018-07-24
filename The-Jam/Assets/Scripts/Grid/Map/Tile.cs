using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile {

    public GameObject myObject = null;

    public SimpleCords position;

    /// <summary>
    /// This is a storage Variable that should allways represent every possible move
    /// </summary>
    public TraversalData Traversals;
    /// <summary>
    /// this is a variable only used after calculating and does not keep up to date without calling an update
    /// </summary>
    public CoverData Cover;
    /// <summary>
    /// This is a storage Variable that shows the IS state
    /// </summary>
    public TileObjectData TileObjects;
    /// <summary>
    /// defines if this tile Passable in general. 
    /// </summary>
    /// <remarks>
    /// this does not update and is used as the basestate of the Tile.
    /// </remarks>
    public bool Passable;
    /// <summary>
    /// shows if it is possible to enter this Tile. 
    /// </summary>
    /// <remarks>
    /// every Tile can be made Obstructed by stacking another one above
    /// </remarks>
    public bool UnObstructed;

    /// <summary>
    /// used to define an empty tile with nothing there, not used
    /// </summary>
    public bool Empty = false;    
    /// <summary>
    /// basic init
    /// </summary>
    public Tile()
    {
        Traversals = new TraversalData(this);
        Cover = new CoverData();
        TileObjects = new TileObjectData(this);
    }
    /// <summary>
    /// basic init with position
    /// </summary>
    /// <param name="position">position of this Tile</param>
    public Tile(SimpleCords position):this()
    {
        this.position = position;
        Passable = true;
        UnObstructed = true;
        Empty = false;
        
    }

    public GameObject SpawnObject()
    {
        // currently just simple
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = position;
        myObject = go;
        return go;
    }

    public void Kill()
    {
        if (myObject!=null)
        {
            GameObject.Destroy(myObject);
        }
    }
    /// <summary>
    /// This methode calculates how much cover this tile provides to another Tile
    /// </summary>
    /// <returns></returns>
    public CoverType ProvidesCoverToTile(SimpleCords otherTileLocation)
    {
        int coverValue = 0;

        Direction thisDir = position.GetDirectionTo(otherTileLocation);

        int heightDifference = position.h - otherTileLocation.h;

        CoverType objectcoverToOtherTile = TileObjects.CoverProvided(thisDir,true);

        coverValue = heightDifference + (int)objectcoverToOtherTile;
        coverValue = Mathf.Min(coverValue, 2);

        if (coverValue<=0)
        {
            return CoverType.None;
        }
        return (CoverType)coverValue;
    }

}
