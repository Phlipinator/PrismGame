using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int maxReflectionCount = 5;
    public int maxSplitCount = 5;
    public float maxStepDistance = 100;

    private LineRenderer lineRenderer;

    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        DrawPredictedReflection(this.transform.position, transform.up, maxReflectionCount, maxSplitCount);
    }

    private void Update()
    {
        DrawPredictedReflection(this.transform.position, transform.up, maxReflectionCount, maxSplitCount);
    }

    void DrawPredictedReflection(Vector2 position, Vector2 direction, int reflectionsRemaining, int splitsRemaining)
    {
        var gizmoHue = (reflectionsRemaining / (this.maxReflectionCount + 1f));
        Gizmos.color = Color.HSVToRGB(gizmoHue, 1, 1);

        RaycastHit2D hit2D = Physics2D.Raycast(position, direction, maxStepDistance);

        if (hit2D) //did we hit somthing?
        {
            Gizmos.DrawLine(position, hit2D.point);
            lineRenderer.positionCount = maxReflectionCount - reflectionsRemaining + 2;
            lineRenderer.SetPosition(this.maxReflectionCount - reflectionsRemaining, position);
            lineRenderer.SetPosition(this.maxReflectionCount - reflectionsRemaining + 1, hit2D.point);
            Gizmos.DrawWireSphere(hit2D.point, 0.25f);

            if (hit2D.transform.gameObject.tag == "Goal")
            {
                Debug.Log("Goal hit");
                //TODO: Insert Goal interaction
            }

            if (hit2D.transform.gameObject.tag == "Obstacle")
            {
                Debug.Log("Obstacle hit");
                //TODO: Insert Obstacle interaction

                GameObject obstacle = hit2D.collider.gameObject;
                ObstacleScript obstacleScript = obstacle.GetComponent<ObstacleScript>();

                obstacleScript.timer -= 1;

                /*if(obstacleScript.timer == 0)
                {
                    Destroy(obstacle);
                }*/
            }

           

            if (hit2D.transform.gameObject.tag == "Prism") //mirror hit. set new pos where hit. reflect angle and make that new direction
            {
                Debug.Log("Mirror Hit");
                direction = Vector2.Reflect(direction, hit2D.normal);
                position = hit2D.point + direction * 0.01f;

                if (reflectionsRemaining > 0)
                {
                    DrawPredictedReflection(position, direction, --reflectionsRemaining, splitsRemaining);
                }

            }
            /*if (hit2D.transform.gameObject.tag == "Splitter") //reflect and go ahead
            {

                Debug.Log("Splitter hit");
                if (splitsRemaining > 0)//go ahead
                {
                    Debug.Log("Splitting");
                    Vector2 splitPosition = new Vector2();
                    Vector2 findOppBegin = hit2D.point + direction * 1f;
                    RaycastHit2D[] findOppHit = Physics2D.RaycastAll(findOppBegin, -direction);
                    for (int i = 0; i <= findOppHit.Length; i++) //findOppHit[i].transform.gameObject != hit2D.transform.gameObject
                    {
                        if (findOppHit[i].transform.gameObject == hit2D.transform.gameObject)
                        {
                            splitPosition = findOppHit[i].point + direction * 0.01f;
                            break;
                        }
                    }

                    DrawPredictedReflection(splitPosition, direction, reflectionsRemaining, --splitsRemaining);
                }


                direction = Vector2.Reflect(direction, hit2D.normal);
                position = hit2D.point + direction * 0.01f;
                if (reflectionsRemaining > 0)//reflect too
                {
                    DrawPredictedReflection(position, direction, --reflectionsRemaining, splitsRemaining);
                }
            }*/
        }
    }
}