using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    //[SerializableField]
    public LayerMask clickablesLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo, 100f, clickablesLayer.value))
            {
                hitInfo.collider.GetComponent<ClickOn>().ClickMe();
            }

            /*RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, clickablesLayer))
            {
                rayHit.collider.GetComponent<ClickOn>().ClickMe();
            }*/
        }
    }
}
