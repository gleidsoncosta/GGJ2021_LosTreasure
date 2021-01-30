using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonManager : MonoBehaviour
{
    float elapsed_time, cur_time, old_time;
    public Animator animator;

    public DragonCollision colisor;
    // Start is called before the first frame update
    
    void Start()
    {
        cur_time = Time.time;
        old_time = cur_time;
        elapsed_time = getNewElapsedTime();
    }

    // Update is called once per frame
    void Update()
    {
        cur_time = Time.time;
        if(cur_time - old_time > elapsed_time){
            //Debug.Log("derruba " +getNCoins()+" moedas");
            elapsed_time = getNewElapsedTime();
            old_time = cur_time;
        }

        getHit();
    }

    private float getNewElapsedTime(float min = 3, float max = 7){
        return Random.Range(min, max);
    }

    private int getNCoins(float min = 1, float max = 5){
        return (int)Random.Range(min, max);
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
