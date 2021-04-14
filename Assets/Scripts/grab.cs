using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class grab : MonoBehaviour
{
    public SteamVR_Action_Boolean rightTrigger;

    private SteamVR_Behaviour_Pose pose;

    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
    void OnTriggerEnter(Collider other)
    {

    }
    void OnTriggerExit(Collider other)
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "shape")
        {
            if (rightTrigger.stateDown)
            {
                other.gameObject.transform.parent = transform;
                Rigidbody target = other.gameObject.GetComponent<Rigidbody>();
                target.isKinematic = true;
            }
            if (rightTrigger.stateUp)
            {
                other.gameObject.transform.parent = null;
                Rigidbody target = other.gameObject.GetComponent<Rigidbody>();

                // do this check since i rotated the cameraRig, the controller velocities go wacky
                Transform origin = pose.origin ? pose.origin : pose.transform.parent;
                if (origin != null)
                {
                    target.velocity = origin.TransformVector(pose.GetVelocity());
                    target.angularVelocity = origin.TransformVector(pose.GetAngularVelocity());
                }
                else
                {
                    target.velocity = pose.GetVelocity();
                    target.angularVelocity = pose.GetAngularVelocity();
                }

                target.isKinematic = false;
            }
        }

    }
}
