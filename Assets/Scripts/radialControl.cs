using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class radialControl : MonoBehaviour
{
    public SteamVR_Action_Boolean rightTrigger;
    public GameObject sphere;
    public GameObject cube;
    public GameObject cylinder;
    public GameObject cuboid;

    private GameObject holdingObj = null;
    private bool registerOnce = true; // need this to stop bug where it keeps spawning if your trigger is down

    private SteamVR_Behaviour_Pose pose;

    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "radialSlice")
        {
            var tempColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            tempColor.a = 1f;
            other.gameObject.GetComponent<SpriteRenderer>().color = tempColor;

            other.gameObject.transform.Translate(new Vector3(0f, 0f, 0.01f));
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "radialSlice")
        {
            var tempColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            tempColor.a = 0.2f;
            other.gameObject.GetComponent<SpriteRenderer>().color = tempColor;

            other.gameObject.transform.Translate(new Vector3(0f, 0f, -0.01f));

            registerOnce = true;
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (rightTrigger.stateDown && registerOnce)
        {
            if (other.gameObject.name == "spawnSphere")
            {
                holdingObj = Instantiate(sphere, transform.position, Quaternion.identity);
                holdingObj.transform.parent = transform;
                holdingObj.GetComponent<Rigidbody>().isKinematic = true;
                registerOnce = false;
            }
            else if (other.gameObject.name == "spawnCube")
            {
                holdingObj = Instantiate(cube, transform.transform.position, Quaternion.identity);
                holdingObj.transform.parent = transform;
                holdingObj.GetComponent<Rigidbody>().isKinematic = true;
                registerOnce = false;
            }
            else if (other.gameObject.name == "spawnCylinder")
            {
                holdingObj = Instantiate(cylinder, transform.transform.position, Quaternion.identity);
                holdingObj.transform.parent = transform;
                holdingObj.GetComponent<Rigidbody>().isKinematic = true;
                registerOnce = false;
            }
            else if (other.gameObject.name == "spawnCuboid")
            {
                holdingObj = Instantiate(cuboid, transform.transform.position, Quaternion.identity);
                holdingObj.transform.parent = transform;
                holdingObj.GetComponent<Rigidbody>().isKinematic = true;
                registerOnce = false;
            }

            if (rightTrigger.stateUp && holdingObj != null)
            {
                holdingObj.transform.parent = null;
                Rigidbody target = holdingObj.GetComponent<Rigidbody>();
                target.isKinematic = false;

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
            }

        }
    }

    void Update()
    {
    }
}
