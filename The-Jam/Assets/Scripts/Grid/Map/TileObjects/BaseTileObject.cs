﻿using System.Collections;
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
    
    public BaseTileObject(Tile sourceTile, Tile connectedTile, Positioning position, CoverType solidity, TraversalType traversalKind)
    {
        SourceTile = sourceTile;
        ConnectedTile = connectedTile;
        this.Position = position;
        Solidity = solidity;
        TraversalKind = traversalKind;
    }

    public BaseTileObject Clone()
    {
        
    }

}