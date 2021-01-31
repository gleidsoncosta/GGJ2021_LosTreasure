using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMove : MonoBehaviour
{
    LevelManager levelManager;
    public float parallax = 1;
    // Start is called before the first frame update
    void Awake() {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left* (levelManager.enviroment_move/parallax) * Time.deltaTime);
        
        
        if(transform.position.x < -40.82248f){
            if(transform.tag == "decoracao"){
                Object.Destroy(gameObject);
            }else{
                float repos = 45.94651f - (-40.82248f - transform.position.x);
                transform.position = new Vector3(repos, transform.position.y, transform.position.z);
            }
        }

    }
}
