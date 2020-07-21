using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class ObstacleScript : MonoBehaviour
{
    
    public float timer = 5.0f;
    public Text txt;

    public float punishment = 5.0f;


    public bool isMoving;
    public bool isMovongRandomly;
    public GameObject Pos1;
    public GameObject Pos2;
    public float speed = 0.03f;


    private TimerScript timerScript;
    private int initialTimer = 100;

    private Vector3 posVector1;
    private Vector3 posVector2;
    private Vector3 moveTowards;

    private bool Collision;

    private int directionX;
    private int directionY;

    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        timerScript = txt.GetComponent<TimerScript>();

        if (!isMoving || isMovongRandomly)
        {
            if (Pos1 == null)
            {
                Pos1 = this.gameObject;
            }
            if (Pos2 == null)
            {
                Pos2 = this.gameObject;
            }
        }

        posVector1 = Pos1.transform.position;
        posVector2 = Pos2.transform.position;

        moveTowards = posVector1;

        random = new System.Random();
        directionX = (random.Next(0, 20) - 10) * 10; //int zwischen -10 und +10
        directionY = (random.Next(0, 20) - 10) * 10;


    }

    // Update is called once per frame
    void Update()
    {

        if(timer <= initialTimer / 2)
        {
            //Farbe ändern o.ä. Aktion
        }

        if(timer <= 0.0f)
        {
            Destroy(this.gameObject);

            timerScript.targetTime -= punishment;

        }

        Vector3 rotation = new Vector3(0, 0, 0.5f);
        transform.Rotate(rotation);



        if (isMoving)
        {
            if (!isMovongRandomly)
            {
                if (moveTowards == posVector1)
                {
                    Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    Vector3 toBeNormalized = posVector1 - position;

                    toBeNormalized.Normalize();

                    Vector3 transformationVector = toBeNormalized * speed;

                    transform.position = transform.position + transformationVector;

                    if (Math.Round(transform.position.x, 1) == Math.Round(posVector1.x, 1))
                    {
                        moveTowards = posVector2;
                    }

                }
                else if (moveTowards == posVector2)
                {
                    Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    Vector3 toBeNormalized = posVector2 - position;

                    toBeNormalized.Normalize();

                    Vector3 transformationVector = toBeNormalized * speed;

                    transform.position = transform.position + transformationVector;

                    if (Math.Round(transform.position.x, 1) == Math.Round(posVector2.x, 1))
                    {
                        moveTowards = posVector1;
                    }
                }
            }
            else
            {
                Debug.Log("random movement");

                RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.zero);

                if (Collision)
                {
                    //Debug.Log("hit something: " + raycastHit2D.collider);
                    Debug.Log("randomize");
                    directionX = (random.Next(0, 20) - 10)*10; //int zwischen -10 und +10
                    directionY = (random.Next(0, 20) - 10)*10;
                    //Collision = false;
                }
                Vector3 direction = new Vector3(directionX, directionY, 0);
                Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Vector3 toBeNormalized = direction - position;

                Debug.Log("toBeNormalized befor normalizing: " + toBeNormalized);
                toBeNormalized.Normalize();

                Debug.Log("toBeNormalized: " + toBeNormalized);

                Vector3 transformationVector = toBeNormalized * speed;

                Debug.Log("transformaitonVector: " + transformationVector);

                transform.position = transform.position + transformationVector;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collision = true;
        Debug.Log("Collision Enter 2D " + collision.collider);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Collision = false;
        Debug.Log("Collision Exit 2D " + collision.collider);
    }


}
