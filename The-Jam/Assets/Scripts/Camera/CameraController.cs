using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform center;

    public GameObject p;

    public float rotSpeed = 250;
    public float damping = 10;
    public float rotAngle = 45;

    private float desiredRot;
    private float desiredHight;

	// Use this for initialization
	void Start () {
        center = p.transform;
        desiredRot = center.eulerAngles.y;
        desiredHight = center.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.anyKey)
        {
            Vector3 direction = new Vector3();
            if (Input.GetKey( KeyCode.S))
            {
                direction = direction + new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = direction + new Vector3(0, 0,-1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction = direction + new Vector3(0, 0,1);
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction = direction + new Vector3(1, 0,0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                desiredRot += rotAngle;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                desiredRot -= rotAngle;
            }
            if (Input.GetAxis("Mouse ScrollWheel")>0f)
            {

                desiredHight += Input.GetAxis("Mouse ScrollWheel");
            }
            center.Translate(direction * (Input.GetKey(KeyCode.LeftShift) ? 30 : 10) * Time.deltaTime, Space.Self);
        }
        var desiredRotQ = Quaternion.Euler(center.eulerAngles.x, desiredRot, center.eulerAngles.z);
        center.rotation = Quaternion.Lerp(center.rotation, desiredRotQ, Time.deltaTime * damping);
        center.position = Vector3.Lerp(center.position, new Vector3(center.position.x, desiredHight, center.position.z), Time.deltaTime * damping);

        
    }
}
