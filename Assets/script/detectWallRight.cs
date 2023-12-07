using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectWallRight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool WallRight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WallRight"))
        {
            transform.position -= new Vector3(10, 0, 0);
        }
    }
}
