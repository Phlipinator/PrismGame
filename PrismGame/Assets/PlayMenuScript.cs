using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuScript : MonoBehaviour
{
    public void PlayLow ()
    {
        SceneManager.LoadScene("Low");
    }

    public void PlayMedium ()
    {
        SceneManager.LoadScene("Medium");
    }

    public void PlayHigh ()
    {
        SceneManager.LoadScene("High");
    }
}
