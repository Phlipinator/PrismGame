using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMe : MonoBehaviour
{
    Renderer rend;
    bool clicked;

    //This script turns the object red when there is a click anywhere on the screen

    private void Update()
    {
        rend = new Renderer();
        clicked = false;

        if (Input.GetMouseButtonDown(0))
        {
            if (!clicked)
            {
                rend.GetComponent<Renderer>().material.color = Color.green;
                clicked = true;
            }

            else
            {
                rend.GetComponent<Renderer>().material.color = Color.red;
                clicked = false;
            }
        }
    }
}

