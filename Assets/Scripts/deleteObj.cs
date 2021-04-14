using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObj : MonoBehaviour
{

    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = new Vector3(0f, 2.2f, -7.32f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1f || Vector3.Distance(transform.position, playerPos) > 12f)
        {
            Destroy(gameObject);
        }
    }
}
