using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public SimpleCords FocusTarget;

    private Vector3 ViewDirection;

	// Use this for initialization
	void Start () {
        FocusTarget = new SimpleCords(0, 0, 0);
        // TODO: Find a way to get the vector to the focuspoint

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.anyKey)
        {
            Vector3 direction = new Vector3();
            if (Input.GetKey( KeyCode.A))
            {
                direction = direction + new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction = direction + new Vector3(0, 0,-1);
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction = direction + new Vector3(0, 0,1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = direction + new Vector3(1, 0,0);
            }

            transform.Translate(direction * (Input.GetKey(KeyCode.LeftShift)?30:10) * Time.deltaTime);
        }


	}
}
