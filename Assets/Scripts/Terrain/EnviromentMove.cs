using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMove : MonoBehaviour
{
    public float h_vel;
    // Start is called before the first frame update
    void Awake() {
        h_vel = 4.0f;    
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left* h_vel * Time.deltaTime);
        
        if(transform.position.x < -40.82248f){
            float repos = 45.94651f - (-40.82248f - transform.position.x);
            transform.position = new Vector3(repos, transform.position.y, transform.position.z);
        }
    }
}
