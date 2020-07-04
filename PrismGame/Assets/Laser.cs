using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private LineRenderer lineRenderer;
    public Transform LaserHit;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;
    }


    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        LaserHit.position = hit.point;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, LaserHit.position);

        Debug.DrawLine(transform.position, hit.point);
    }
}