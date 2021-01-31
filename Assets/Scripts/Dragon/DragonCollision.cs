using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCollision : MonoBehaviour
{
    public bool projetil;
    public bool hard;
    // Start is called before the first frame update
    private void Awake() {
        projetil = false;
        hard = false;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "projetil"){
            projetil = true;
            if(other.gameObject.name.Contains("pesado")){
                Object.Destroy(other.gameObject);
                hard = true;
                
            }else{
                Object.Destroy(other.gameObject);
                hard = false;
            }
        }
    }

    
}
