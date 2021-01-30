using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour
{

    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        vel = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.up*vel*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.down*vel*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right*vel*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left*vel*Time.deltaTime);
        }*/
    }
}
