using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercontrols : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 1f;
    public static int width = 100;
    public static int height = 200;
    private static Transform[,] grid = new Transform[width, height];
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
            if (!ValidMove())
                transform.position -= new Vector3(-10, 0, 0);
        }
        else if (Input.GetButtonDown("Right"))
        {
            transform.position += new Vector3(10, 0, 0);
            if(!ValidMove())
                transform.position -= new Vector3(10, 0, 0);
        }

        //timer before block moves down
        if (Time.time - previousTime > (Input.GetButton("Down") ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -10, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -10, 0);
                AddToGrid();
                CheckForLines();

                this.enabled = false;
                FindObjectOfType<spawner>().NewPackage();


            }
            previousTime = Time.time;
        }
        //rotation
        if (Input.GetButtonDown("Rotate"))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if(!ValidMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
        }
    }
    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null)
                return false;
        }

        return true;
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    void CheckForLines()
    {
        for (int i = height-1; i >= 0; i--)
        {

            Debug.Log("checking line" + i);
            if (HasLine(i))
            {
                Debug.Log("line detected");
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for(int j =0; j< width; j++)
        {
            if (grid[j, i] == null)
            {
                Debug.Log($"Empty space at {j}, {i}");
                
                
                return false;
            }
            else
            {
                Debug.Log($"block detected at {j}, {i}");
            }
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j= 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
        Debug.Log("delete complete");
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] == null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 10, 0);
                }
            }
        }
    }


}
