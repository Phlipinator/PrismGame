using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public int maxReflectionCount = 5;
    public int maxSplitCount = 5;
    public float maxStepDistance = 100;


    private LineRenderer lineRenderer;

    public GameObject timerText;
    private TimerScript timerScript;




    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
        timerScript = timerText.GetComponent<TimerScript>();
    }

    private void Update()
    {
        DrawPredictedReflection(this.transform.position, transform.up, maxReflectionCount, maxSplitCount);
    }

    void DrawPredictedReflection(Vector2 position, Vector2 direction, int reflectionsRemaining, int splitsRemaining)
    {
        var gizmoHue = (reflectionsRemaining / (this.maxReflectionCount + 1f));

        RaycastHit2D hit2D = Physics2D.Raycast(position, direction, maxStepDistance);

        if (hit2D) //did we hit something?
        {
            lineRenderer.positionCount = maxReflectionCount - reflectionsRemaining + 2;
            lineRenderer.SetPosition(this.maxReflectionCount - reflectionsRemaining, position);
            lineRenderer.SetPosition(this.maxReflectionCount - reflectionsRemaining + 1, hit2D.point);

            if (hit2D.transform.gameObject.tag == "Goal")
            {
                Debug.Log("Goal hit");

                int timeLeft = (int)timerScript.targetTime;
                DataScript.TimeLeft = timeLeft;

                SceneManager.LoadScene(sceneName: "EndScene");

            }

            if (hit2D.transform.gameObject.tag == "Obstacle")
            {
                Debug.Log("Obstacle hit");
                //TODO: Insert Obstacle interaction

                GameObject obstacle = hit2D.collider.gameObject;
                ObstacleScript obstacleScript = obstacle.GetComponent<ObstacleScript>();

                float time = Time.deltaTime;

                obstacleScript.timer -= time;

            }

           

            if (hit2D.transform.gameObject.tag == "Prism") //mirror hit. set new pos where hit. reflect angle and make that new direction
            {
                // Debug.Log("Mirror Hit");
                direction = Vector2.Reflect(direction, hit2D.normal);
                position = hit2D.point + direction * 0.01f;

                if (reflectionsRemaining > 0)
                {
                    DrawPredictedReflection(position, direction, --reflectionsRemaining, splitsRemaining);
                }

            }
            
        }
    }
}