using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeParser : MonoBehaviour
{

    public Text txt;
    int timeLeft;

    // Start is called before the first frame update
    void Start()
    {
 
        timeLeft = DataScript.TimeLeft;
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = timeLeft.ToString();
    }
}
