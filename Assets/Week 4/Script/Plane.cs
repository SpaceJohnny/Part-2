using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;

    void OnMouseDown()
    {
       points = new List<Vector2>();
       Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
       points.Add(currentPosition);

       lineRenderer.positionCount = 1;
       lineRenderer.SetPosition(0, transform.position);
    }

    void OnMouseDrag()
    {
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //clever stuff
        if(Vector2.Distance(currentPosition, lastPosition) > newPointThreshold)
        {
            points.Add(currentPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
            lastPosition = currentPosition;
        }

        lastPosition = currentPosition;
    }

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }
}
