using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectWallLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool WallLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WallLeft"))
        {
            transform.position -= new Vector3(-10, 0, 0);
        }
    }

}
