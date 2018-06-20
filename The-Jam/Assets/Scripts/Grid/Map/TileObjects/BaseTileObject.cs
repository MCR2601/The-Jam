using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is for an object that exists on/between 1 or more Tiles
/// This can be a tree, fence, small wall, high wall, etc...
/// </summary>
public class BaseTileObject {

    /// <summary>
    /// this is the name of the displaymodel
    /// </summary>
    public string ModelName;
    /// <summary>
    /// For special models that have a center that is not directly where it will be placed
    /// </summary>
    public SimpleCords ModelOffset;
    /// <summary>
    /// If this object has a blocking hitbox
    /// </summary>
    public bool HasHitBox;
    /// <summary>
    /// This is the tile this is on
    /// </summary>
    public Tile SourceTile;
    /// <summary>
    /// This is the tile which shares this object, if avaiable. (e.g.: walls or fences)
    /// </summary>
    public Tile ConnectedTile;
    /// <summary>
    /// determins if this object is in the center or is shared with an other tile
    /// </summary>
    public bool isCenter;
    /// <summary>
    /// Where the Object should be placed on the SourceTile
    /// </summary>
    public Positioning Position;
    /// <summary>
    /// This shows how Solid this object is 
    /// None    -   This Object does neither has cover nor changes pathing
    /// partial -   This Object provides partial cover
    ///     center  -   Untraversable
    ///     side    -   May be traversable, see traversalKind as variable for this
    /// Full    -   This object provides Full cover
    ///     center  -   Untraversable
    ///     side    -   untraversable ( doors can be opened and change this)
    /// </summary>
    public CoverType Solidity;
    /// <summary>
    /// This shows how this object should be traversed, if possible
    /// </summary>
    public TraversalType TraversalKind;
    
    public BaseTileObject(bool isCenter, CoverType solidity, TraversalType traversalKind)
    {
        if (isCenter)
        {
            Position = Positioning.Center;
            this.isCenter = isCenter;
        }
        else
        {
            this.isCenter = isCenter;
        }
        Solidity = solidity;
        TraversalKind = traversalKind;
    }

    public BaseTileObject Place(Tile source)
    {
        SourceTile = source;
        return this;
    }

    public BaseTileObject Place(Tile source, Tile connected, Positioning pos)
    {
        SourceTile = source;
        ConnectedTile = connected;
        Position = pos;
        
        return this;
    }

    public BaseTileObject Clone()
    {
        BaseTileObject temp = new BaseTileObject(isCenter, Solidity, TraversalKind);
        return temp;
    }
}