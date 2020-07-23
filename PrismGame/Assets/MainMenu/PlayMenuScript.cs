using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuScript : MonoBehaviour
{
    public void PlayLow ()
    {
        DataScript.Gamemode = 0;
        Debug.Log("Loading Low, Gamemode: " + DataScript.Gamemode);
        SceneManager.LoadScene("Low");
        
    }

    public void PlayMedium ()
    {
        DataScript.Gamemode = 1;
        Debug.Log("Loading mid, Gamemode: " + DataScript.Gamemode);
        SceneManager.LoadScene("Medium");
        
    }

    public void PlayHigh ()
    {
        DataScript.Gamemode = 2;
        SceneManager.LoadScene("High");
        
    }
}
