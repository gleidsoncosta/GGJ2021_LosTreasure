using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMovement : MonoBehaviour
{
    
    public List<Transform> gb_left;
    public List<Transform> gb_right;
    public List<GameObject> clouds;
    List<int> layers;
    // Start is called before the first frame update  
    float elapsed_time, cur_time, old_time;
    List<GameObject> gb;
    private void Awake() {
        layers = new List<int>{5, 8, 12};
    }
    
    void Start()
    {
        cur_time = Time.time;
        old_time = cur_time;
        elapsed_time = Random.Range(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        cur_time = Time.time;
        if(cur_time - old_time > elapsed_time){
            //Debug.Log("derruba " +getNCoins()+" moedas");
            foreach(Transform t in gb_left){
                int n = (int)Random.Range(1, 3);
            }
            
            
            //GameObject objeto = Instantiate();
            
            elapsed_time = Random.Range(5, 10);
            old_time = cur_time;
        }

    }
}
