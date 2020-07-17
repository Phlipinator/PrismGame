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


        SceneManager.LoadScene(sceneName: sceneName);
    }
}
