using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject gb = new GameObject("teste");
        gb.transform.position = transform.GetComponent<MeshFilter>().mesh.bounds.center;
        gb.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.GetComponent<MeshFilter>().mesh.bounds.size);
        Debug.Log(transform.GetComponent<MeshFilter>().mesh.bounds.center);
    }
}
