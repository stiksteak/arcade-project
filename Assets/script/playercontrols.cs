using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrols : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 1f;
    public float xRange = 35;
    public float yRange = 95;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Left"))
        {
            transform.position += new Vector3(-10, 0, 0);
        }
        else if (Input.GetButtonDown("Right"))
        {
            transform.position += new Vector3(10, 0, 0);
        }

        //timer before block moves down
        if(Time.time - previousTime > (Input.GetButton("Down") ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -10, 0);
            previousTime = Time.time;
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, -transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        //rotation
        if (Input.GetButtonDown("Rotate"))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        }
    }
}
