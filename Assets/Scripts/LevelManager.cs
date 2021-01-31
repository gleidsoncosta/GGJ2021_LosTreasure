using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float enviroment_move;
    public PlayerMove playerMove;

    public int moedas;
    // Start is called before the first frame update
    private void Awake() {
        enviroment_move = 7.0f;
    }
    
    void Start()
    {
        enviroment_move = 7.0f;
    }

    // Update is called once per frame
    public void increseMove()
    {
            enviroment_move += 0.5f;
    }
}
