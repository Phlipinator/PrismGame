using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser4 : MonoBehaviour
{
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        DrawLaser();
    }

    void DrawLaser()
    {
        int laserReflected = 0; //How many times it got reflected
        int segmentsCounter = 1; //How many line segments are there
        bool loopActive = true; //Is the reflecting loop active?
        Vector2 laserDirection = transform.up; //direction of the next laser
        Vector2 lastLaserPosition = transform.position; //origin of the next laser

        int laserLimit = 10;

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        while (loopActive)
        {
            RaycastHit2D hit = Physics2D.Raycast(lastLaserPosition, laserDirection);

            if (hit.transform.gameObject.tag.Equals("Prism"))
            {
                laserReflected++;
                segmentsCounter += 2;
                lineRenderer.positionCount = segmentsCounter;
                lineRenderer.SetPosition(segmentsCounter - 2, lastLaserPosition);
                lineRenderer.SetPosition(segmentsCounter - 1, hit.point);
                lastLaserPosition = hit.point;
                laserDirection = Vector3.Reflect(laserDirection.normalized, hit.normal);
            }
            else if(hit.transform.gameObject.tag.Equals("Wall"))
            {
                laserReflected++;
                segmentsCounter++;
                lineRenderer.positionCount = segmentsCounter;
                lineRenderer.SetPosition(segmentsCounter - 1, hit.point);
                lastLaserPosition = hit.point;
                laserDirection = Vector3.Reflect(laserDirection.normalized, hit.normal);


                loopActive = false;
            }
            else
            {
                lineRenderer.SetPosition(segmentsCounter - 1, lastLaserPosition);
                lineRenderer.SetPosition(segmentsCounter, (lastLaserPosition + (laserDirection.normalized * 10)));

                loopActive = false;
            }

            if (laserReflected > laserLimit)
                loopActive = false;
        }

    }
}
