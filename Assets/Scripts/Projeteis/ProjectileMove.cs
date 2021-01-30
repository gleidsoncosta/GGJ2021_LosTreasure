using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public Transform target;
    public Rigidbody _rigidbody;
    public float force;
    // Start is called before the first frame update
    void Awake() {
        target = GameObject.Find("Dragon").transform;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        Vector3 f = target.position - transform.position;
        f = f.normalized;
        f = f*force;
        _rigidbody.AddForce(f);
    }
}
