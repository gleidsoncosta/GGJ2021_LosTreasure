using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public bool direction;
    public float h_vel;

    public float parallax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direction)
            transform.Translate(Vector3.right* (h_vel/parallax) * Time.deltaTime);
    }
}
