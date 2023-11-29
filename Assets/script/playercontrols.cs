using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class playercontrols : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 1f;
    public static int height = 20;
    public static int width = 10;
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
                if(!ValidMove())
                transform.position = new Vector3(-10, 0, 0);
        }
        else if (Input.GetButtonDown("Right"))
        {
            transform.position += new Vector3(10, 0, 0);
            if (!ValidMove())
                transform.position = new Vector3(10, 0, 0);
        }

        //timer before block moves down
        if(Time.time - previousTime > (Input.GetButton("Down") ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -10, 0);
            if (!ValidMove())
                transform.position = new Vector3(0, -10, 0);
            previousTime = Time.time;
        }

    }

    bool ValidMove()
    {
       /* foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.position.x);
            int roundedY = Mathf.RoundToInt(children.position.y);

            if(roundedX < 5 || roundedX >= width || roundedY < 5 ||roundedY >= height)
            {
                return false;
            }
        }*/

        return true;
    }
}
