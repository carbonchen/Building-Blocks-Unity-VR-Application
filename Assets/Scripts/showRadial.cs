using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showRadial : MonoBehaviour
{

    public GameObject leftController;
    public GameObject radial;

    public GameObject spawnCube;
    public GameObject spawnSphere;
    public GameObject spawnCylinder;
    public GameObject spawnCuboid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftController.transform.eulerAngles.z > 50f && leftController.transform.eulerAngles.z < 125f)
        {
            radial.SetActive(true);
        }
        else
        {
            Vector4 originalColor = new Vector4(1f, 1f, 1f, 0.2f);
            if (spawnSphere.GetComponent<SpriteRenderer>().color.a == 1f)
            {
                spawnSphere.GetComponent<SpriteRenderer>().color = originalColor;
                spawnSphere.transform.Translate(new Vector3(0f, 0f, -0.01f));
            }
            if (spawnCylinder.GetComponent<SpriteRenderer>().color.a == 1f)
            {
                spawnCylinder.GetComponent<SpriteRenderer>().color = originalColor;
                spawnCylinder.transform.Translate(new Vector3(0f, 0f, -0.01f));
            }
            if (spawnCube.GetComponent<SpriteRenderer>().color.a == 1f)
            {
                spawnCube.GetComponent<SpriteRenderer>().color = originalColor;
                spawnCube.transform.Translate(new Vector3(0f, 0f, -0.01f));
            }
            if (spawnCuboid.GetComponent<SpriteRenderer>().color.a == 1f)
            {
                spawnCuboid.GetComponent<SpriteRenderer>().color = originalColor;
                spawnCuboid.transform.Translate(new Vector3(0f, 0f, -0.01f));
            }
            radial.SetActive(false);
        }
    }
}
