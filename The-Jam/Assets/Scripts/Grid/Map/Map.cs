using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public int mapXSize = 1;

    public int mapYSize = 1;

    public int mapZSize = 1;

    public Tile[,,] map;

    // Use this for initialization
    void Start () {
        this.map = new Tile[mapXSize, mapYSize, mapZSize];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
