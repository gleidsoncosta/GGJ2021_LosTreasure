using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    
    public bool direction;
    public List<GameObject> Clouds;

    float elapsed_time, cur_time, old_time;

    LevelManager levelManager;
    List<int> layers;
    // Start is called before the first frame update
    private void Awake() {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    
    void Start()
    {
        cur_time = Time.time;
        old_time = cur_time;
        elapsed_time = Random.Range(0, 5);
        layers = new List<int>{5, 8, 12};
    }

    // Update is called once per frame
    void Update()
    {
        cur_time = Time.time;
        if(cur_time - old_time > elapsed_time){
            //Debug.Log("derruba " +getNCoins()+" moedas");
            int n = (int)Random.Range(0, Clouds.Count);
            GameObject gb = Instantiate(Clouds[n]);
            gb.transform.position = transform.position;
            gb.transform.parent = transform;
            int val = layers[(int)Random.Range(0, layers.Count)];
            gb.transform.GetComponent<SpriteRenderer>().sortingOrder = val;
            gb.transform.GetComponent<Cloud>().direction = direction;
            gb.transform.GetComponent<Cloud>().h_vel = 5;
            gb.transform.GetComponent<Cloud>().parallax = 36/val;
            elapsed_time = Random.Range(10, 30);
            old_time = cur_time;
        }

    }
}
