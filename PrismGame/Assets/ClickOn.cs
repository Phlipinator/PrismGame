using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material green;

    private SpriteRenderer sprite;

    // Start is called before the first frame update

    void Start()
    {
        //myRenderer = GetComponent<SpriteRenderer>();

        sprite = GetComponent<SpriteRenderer>();
    }

    public void ClickMe()
    {
        sprite.color = new Color(1, 0, 0, 1);
        //myRenderer.material = green;
    }

}
