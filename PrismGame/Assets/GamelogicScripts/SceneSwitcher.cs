using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Text txt;

    public void changeScene(string sceneName)
    {
        Debug.Log("Gammode: " + DataScript.Gamemode);

        if (sceneName == "GameScene")
        {
            if (DataScript.Gamemode == 0)
            {
                SceneManager.LoadScene(sceneName: "Low");
            } else if (DataScript.Gamemode == 1)
            {
                SceneManager.LoadScene(sceneName: "Medium");
            } else if (DataScript.Gamemode == 2)
            {
                SceneManager.LoadScene(sceneName: "High");
            } else if (DataScript.Gamemode == 3)
            {
                SceneManager.LoadScene(sceneName: "Tutorial");
            }
        } else {
            if (sceneName == "Low")
            {
                DataScript.Gamemode = 0;
            }
            if (sceneName == "Medium")
            {
                DataScript.Gamemode = 1;
            }
            if (sceneName == "High")
            {
                DataScript.Gamemode = 2;
            }
            if (sceneName == "Tutorial")
            {
                DataScript.Gamemode = 3;
            }
            SceneManager.LoadScene(sceneName: sceneName);
        }
        
    }
}
