using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class colorChanger : MonoBehaviour
{
    public SteamVR_Action_Boolean rightTrigger;

    private float timer = 0.0f;
    private bool pressedBool = false;
    private GameObject pressedObj = null;

    private GameObject lastSelected;

    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {

    }
    void OnTriggerExit(Collider other)
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "button")
        {
            if (rightTrigger.stateDown && !pressedBool)
            {
                // animation
                pressedBool = true;
                pressedObj = other.gameObject;
                pressedObj.transform.Translate(new Vector3(0f, -0.005f, 0f));

                // assign color
                if (lastSelected != null)
                {
                    lastSelected.GetComponent<Renderer>().material.color = pressedObj.gameObject.GetComponent<Renderer>().material.color;
                }
            }


        }
    }

    void Update()
    {
        lastSelected = GetComponent<highlight>().lastSelected;

        // animation
        if (pressedBool)
        {
            timer += Time.deltaTime;
        }
        if (pressedBool && pressedObj != null && timer > 0.5f)
        {
            pressedObj.transform.Translate(new Vector3(0f, 0.005f, 0f));
            pressedObj = null;
            pressedBool = false;
            timer = 0.0f;
        }
    }
}
