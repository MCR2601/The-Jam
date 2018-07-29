using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is for an object that exists on/between 1 or more Tiles
/// This can be a tree, fence, small wall, high wall, etc...
/// </summary>
public class BaseTileObject {
    /// <summary>
    /// Stores the Name of the Object
    /// </summary>
    public string ObjectName;
    /// <summary>
    /// this is the name of the displaymodel
    /// </summary>
    public string ModelName;
    /// <summary>
    /// For special models that have a center that is not directly where it will be placed
    /// </summary>
    public Vector3 ModelOffset;
    /// <summary>
    /// If this object has a blocking hitbox
    /// </summary>
    public bool HasHitBox;
    /// <summary>
    /// This is the tile this is on
    /// </summary>
    public Tile SourceTile;
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

    public BaseTileObject(string objectName, string modelName, Vector3 modelOffset, bool hasHitBox, bool isCenter, CoverType solidity, TraversalType traversalKind)
    {
        ObjectName = objectName;
        ModelName = modelName;
        ModelOffset = modelOffset;
        HasHitBox = hasHitBox;
        this.isCenter = isCenter;
        Solidity = solidity;
        TraversalKind = traversalKind;
        if (this.isCenter)
        {
            Position = Positioning.Center;
        }
    }

    public BaseTileObject Place(Tile source)
    {
        SourceTile = source;
        SpawnVisuals();
        return this;
    }

    public BaseTileObject Place(Tile source, Positioning direction)
    {
        SourceTile = source;

        Position = direction;
        SpawnVisuals();
        return this;
    }

    private void SpawnVisuals()
    {
        if (isCenter == true)
        {
            // we dont need any other location nor orientation
            GameObject go = Resources.Load<GameObject>(ModelName);
            go = GameObject.Instantiate(go);
            go.transform.position = (Vector3)(SourceTile.position+new SimpleCords(0,0,1)) + ModelOffset;
            
        }
        else
        {
            // position is average of source and connected
            GameObject go = Resources.Load<GameObject>(ModelName);
            go = GameObject.Instantiate(go);
            go.transform.position = ((Vector3)(SourceTile.position + SourceTile.position.GetInDirection((Direction)(int)Position))) / 2 + new Vector3(0,1,0) + ModelOffset;

            // orientation has to be Calculated based on direction
            go.transform.rotation = Quaternion.Euler(go.transform.rotation.eulerAngles.x,  go.transform.rotation.eulerAngles.y + 90 * ((int)Position + 1), 0);
        }
    }


    public BaseTileObject Clone()
    {
        BaseTileObject temp = new BaseTileObject(ObjectName,ModelName,ModelOffset,HasHitBox,isCenter,Solidity,TraversalKind);
        return temp;
    }
}