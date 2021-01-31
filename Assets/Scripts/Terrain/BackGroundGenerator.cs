using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : MonoBehaviour
{
    Vector3 position;
    LevelManager levelManager;

    public float decor_density_min;
    public float decor_density_max;

    public List<GameObject> floresta;
    // Start is called before the first frame update
    public float elapsed_time, cur_time, old_time;
    private void Awake() {
        position = new Vector3(73.4700012f,-0.550000012f,7.10799742f);
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        decor_density_min = 6;
        decor_density_max = 15;
    }

    void Start()
    {
        cur_time = Time.time;
        old_time = cur_time;
        elapsed_time = Random.Range(decor_density_min/levelManager.enviroment_move,decor_density_min/levelManager.enviroment_move);
        
    }

    // Update is called once per frame
    void Update()
    {
        cur_time = Time.time;
        if(cur_time - old_time > elapsed_time){
            int rand_tree = (int)Random.Range(0, floresta.Count-1);
            GameObject gb = Instantiate(floresta[rand_tree]);
            Vector3 pos_root = gb.transform.Find("root").transform.localPosition;
            gb.transform.position = position-pos_root;
            gb.transform.parent = transform;
            gb.AddComponent<EnviromentMove>();
            old_time = cur_time;
            elapsed_time = Random.Range(decor_density_min/levelManager.enviroment_move,decor_density_min/levelManager.enviroment_move);
            Debug.Log(levelManager.enviroment_move + " " + Time.deltaTime + " " 
                + (decor_density_min/levelManager.enviroment_move, decor_density_max/levelManager.enviroment_move));
        }
    }


}
