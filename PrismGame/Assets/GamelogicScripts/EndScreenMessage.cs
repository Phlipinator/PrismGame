using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenMessage : MonoBehaviour
{
    public Text winOrLoose;
    public Text reason;

    public AudioSource winningSound;
    public AudioSource loosingSound;

    int timeLeft;

    // Start is called before the first frame update
    void Start()
    {

        timeLeft = DataScript.TimeLeft;

        if (timeLeft <= 0)
        {
            winOrLoose.text = "You Lost ...";
            reason.text = "time's up";

            loosingSound.Play();
        }
        else
        {
            winOrLoose.text = "Congratulations, you won!";
            reason.text = "You still have " + timeLeft.ToString() + " seconds on the clock";

            winningSound.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
