using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public float targetTime = 20.0f;
    public Text txt;


    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

        int hudTimer = (int)targetTime;

        if (hudTimer <= 0)
        {
            txt.text = "0";
        }
        else
        {
            txt.text = hudTimer.ToString();
        }

        void timerEnded()
        {
            Debug.Log("Timer has Ended!");
            DataScript.TimeLeft = 0;

            SceneManager.LoadScene(sceneName: "EndScene");

           
        }


    }
}
