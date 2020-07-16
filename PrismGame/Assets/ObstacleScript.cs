using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private int initialTimer = 100;
    public int timer = 100;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        
    }
}
