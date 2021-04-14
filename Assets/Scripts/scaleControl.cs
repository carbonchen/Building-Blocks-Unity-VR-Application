using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class scaleControl : MonoBehaviour
{
    public SteamVR_Action_Boolean rightTrigger;
    public Transform dial;

    private GameObject lastSelected;
    private bool holding = false;
    private Vector3 prevHandRot;
    private Vector3 prevDialRot;
    private Vector3 prevScale;

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
        if (other.gameObject.tag == "dial")
        {
            if (rightTrigger.stateDown)
            {
                prevHandRot = new Vector3(0f, transform.rotation.eulerAngles.y, 0f);
                prevDialRot = new Vector3(0f, dial.rotation.eulerAngles.y, 0f);
                if (lastSelected != null)
                {
                    prevScale = lastSelected.transform.localScale;
                }
                holding = true;
            }

        }
    }

    void Update()
    {
        lastSelected = GetComponent<highlight>().lastSelected;
        if (holding)
        {
            float yDiff = transform.eulerAngles.y - prevHandRot.y;
            dial.eulerAngles = new Vector3(0f, prevDialRot.y + (yDiff * 3f), 0f);

            if (lastSelected != null)
            {
                float newScale = Mathf.Pow(1.001927f, yDiff * 3f);
                lastSelected.transform.localScale = new Vector3(prevScale.x * newScale, prevScale.y * newScale, prevScale.z * newScale);
            }

            if (rightTrigger.stateUp)
            {
                holding = false;
            }
        }
    }
}
