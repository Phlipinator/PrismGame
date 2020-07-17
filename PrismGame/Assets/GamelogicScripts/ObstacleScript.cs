using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleScript : MonoBehaviour
{
    private int initialTimer = 100;
    public int timer = 100;
    public Text txt;

    public float punishment = 5.0f;

    private TimerScript timerScript;

    public GameObject Pos1;
    public GameObject Pos2;

    private Vector3 posVector1;
    private Vector3 posVector2;

    // Start is called before the first frame update
    void Start()
    {
        timerScript = txt.GetComponent<TimerScript>();

        posVector1 = Pos1.transform.position;
        posVector2 = Pos2.transform.position;

        Debug.Log("PosVector1: " + posVector1);
       
    }

    // Update is called once per frame
    void Update()
    {

        if(timer <= initialTimer / 2)
        {
            //Farbe ändern o.ä. Aktion
        }

        if(timer == 0)
        {
            Destroy(this.gameObject);

            timerScript.targetTime -= punishment;

        }

 
    
      
        if (transform.position != posVector1)
        {
            //transform.position = new Vector3(transform.position.x + 0.001f, transform.position.y + 0.001f, transform.position.z);

           /* 
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 toBeNormalized = posVector1 - position;

            Debug.Log("vector: " + toBeNormalized);

            Vector3 normalized = Vector3.Normalize(toBeNormalized);

            Debug.Log("Normalized: " + normalized);

            transform.position = normalized * 0.001f;
           */

           transform.position = new Vector3(transform.position.x + (posVector1.x - transform.position.x) * 0.001f,
             transform.position.y + (posVector1.y - transform.position.y) * 0.001f, transform.position.z);
            




        }
        else
        {
           transform.position = new Vector3(transform.position.x + (posVector1.x - transform.position.x) * 0.001f,
                transform.position.y + (posVector1.y - transform.position.y) * 0.001f, transform.position.z);
        }
    
    
     



    }


}
