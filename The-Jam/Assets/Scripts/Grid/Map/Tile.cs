using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile {

    GameObject myObject = null;

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

    public GameObject SpawnObject()
    {
        // currently just simple
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = position;

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
