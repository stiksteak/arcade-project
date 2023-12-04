using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] Packages;
    // Start is called before the first frame update
    void Start()
    {
        NewPackage();
    }

    // Update is called once per frame
    public void NewPackage()
    {
        Instantiate(Packages[Random.Range(0, Packages.Length)], transform.position, Quaternion.identity);
    }
}
