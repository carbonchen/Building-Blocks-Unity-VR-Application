using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class highlight : MonoBehaviour
{
    public GameObject lastSelected = null;

    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "shape")
        {
            if (lastSelected != null)
            {
                lastSelected.GetComponent<Outline>().OutlineWidth = 0.0f;
            }
            lastSelected = other.gameObject;
            lastSelected.GetComponent<Outline>().OutlineWidth = 5.0f;
        }
    }
    void OnTriggerExit(Collider other)
    {

    }
    void OnTriggerStay(Collider other)
    {

    }
}
