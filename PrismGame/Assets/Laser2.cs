using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser2 : MonoBehaviour
{
    public float beamLength;
    private LineRenderer lineRenderer;
    public Transform laserHit;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 endPosition = transform.position + (transform.right * beamLength);
        //lineRenderer.SetPositions(new Vector3[] { transform.position, endPosition });

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserHit.position);
    }
}
