using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCubeTest : MonoBehaviour {

    private Grid grid;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
            }
        }
    }

    private void PlaceCubeNear(Vector3 nearPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(nearPoint);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = finalPosition;
    }
}
