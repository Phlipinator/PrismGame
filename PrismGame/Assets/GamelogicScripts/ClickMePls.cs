using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMePls : MonoBehaviour
{

    bool clicked = false;

    public Sprite greenSprite;
    public Sprite redSprite;

    void OnMouseDown()
    {
        if (!clicked)
        {
            //this.GetComponent<Renderer>().material.color = Color.green;
            this.GetComponent<SpriteRenderer>().sprite = greenSprite;
            clicked = true;

           
        }

        else
        {
            //this.GetComponent<Renderer>().material.color = Color.red;
            this.GetComponent<SpriteRenderer>().sprite = redSprite;
            clicked = false;
        }
       
    }

    private void Update()
    {
        //this rotates the sprite if it is clicked, according to the arrow keys
        if (clicked)
        {
            float direction = Input.GetAxis("Horizontal");
            Vector3 rotation = new Vector3(0, 0, -direction * Time.deltaTime * 35f);
            transform.Rotate(rotation);
        }
    }

   
}
