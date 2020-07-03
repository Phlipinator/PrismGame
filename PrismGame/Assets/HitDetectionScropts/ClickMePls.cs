using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMePls : MonoBehaviour
{

    bool clicked = false;

    void OnMouseDown()
    {
            if (!clicked)
            {
                this.GetComponent<Renderer>().material.color = Color.green;
                clicked = true;

                //The rotation part does not work jet
                /*if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(Vector3.right * 30 * Time.deltaTime);
                }*/
            }

            else
            {
                this.GetComponent<Renderer>().material.color = Color.red;
                clicked = false;
            }
       
    }

    private void Update()
    {
        //this rotates the sprite if it is clicked, according to the arrow keys
        if (clicked)
        {
            float direction = Input.GetAxis("Horizontal");
            Vector3 rotation = new Vector3(0, 0, -direction);
            transform.Rotate(rotation);
        }
    }

    /*

    //This Part should turn the Prism Red again when there is a click anywhere else on the screen
    //but it does not work..
   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            {
            if (clicked)
            {
                this.GetComponent<Renderer>().material.color = Color.red;
                clicked = false;
            }
        }
    }
    */
}
