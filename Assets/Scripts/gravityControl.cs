using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class gravityControl : MonoBehaviour
{
    public SteamVR_Action_Boolean rightTrigger;
    public Transform slider;
    public Transform sliderLine;

    private bool attached = false;

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
        if (other.gameObject.tag == "slider")
        {
            if (rightTrigger.stateDown)
            {
                attached = true;
            }
        }
    }

    void Update()
    {
        if (attached)
        {
            Vector3 sliderPos = slider.position;
            sliderPos.x = transform.position.x;
            sliderPos.x = Mathf.Clamp(sliderPos.x, -0.494f, -.25f);
            slider.position = sliderPos;
            if (rightTrigger.stateUp)
            {
                attached = false;
            }
        }
        // equation mapping (-0.25, -0.494) to (0, -19.62)
        // (-0.52, -9.81) is normal gravity
        float gravAccel = (80.40983606557377f * slider.position.x) + 20.102459016393443f;
        Physics.gravity = new Vector3(0f, gravAccel, 0f);
    }
}
