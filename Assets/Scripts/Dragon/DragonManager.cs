using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonManager : MonoBehaviour
{
    float elapsed_time, cur_time, old_time;
    //float elapsed_time2, cur_time2, old_time2;
    public Animator animator;

    public Transform ground;
    public GameObject coin;

    public DragonCollision colisor;
    // Start is called before the first frame update
    int n_moedas;
    void Start()
    {
        cur_time = Time.time;
        old_time = cur_time;
        elapsed_time = getNewElapsedTime();

        //cur_time2 = Time.time;
        //old_time2 = cur_time2;
        //elapsed_time2 = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        cur_time = Time.time;
        if(cur_time - old_time > elapsed_time){
            n_moedas += getNCoins();
            elapsed_time = getNewElapsedTime();
            old_time = cur_time;
        }

        
        /*if(n_moedas>0){
            cur_time2 = Time.time;
            if(cur_time2 - old_time2 > elapsed_time2){
                old_time2 = cur_time2;

                GameObject gb = (GameObject)Instantiate(coin);
                gb.transform.position = transform.position;
                gb.transform.parent = ground;
                n_moedas--;
            }
        }*/

        getHit();
    }

    private float getNewElapsedTime(float min = 3, float max = 7){
        return Random.Range(min, max);
    }

    private int getNCoins(int min = 2, int max = 5){
        int n = (int)Random.Range(min, max); 
        return n;
    }

    private void getHit(){
        if(colisor.projetil){
            colisor.projetil = false;
            if(colisor.hard){
                animator.SetBool("heavy_hit", true);
            }else{
                animator.SetBool("light_hit", true);
            }
        }else{
            animator.SetBool("light_hit", false);
            animator.SetBool("heavy_hit", false);
        }
    } 
}
