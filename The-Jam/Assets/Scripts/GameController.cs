using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this manages the entire game
/// </summary>
public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Map.Spawn();

        }
	}
}
