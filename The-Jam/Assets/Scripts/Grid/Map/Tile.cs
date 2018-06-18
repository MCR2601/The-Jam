using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile {

    public GameObject myObject = null;

    public SimpleCords position;

    public TraversalData Traversals;
    public CoverData Cover;

    public bool Passable;

    public bool Empty = false;    

    public Tile()
    {
        Traversals = new TraversalData(this);
        Cover = new CoverData();
    }

    public Tile(SimpleCords position):this()
    {
        this.position = position;
        Passable = true;
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

}
