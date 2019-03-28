using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMasterControl : MonoBehaviour
{

    public static int turnTimer = 1;
    public static bool playerTurn;
    // Start is called before the first frame update
    void Start()
    {
        //Randoms who starts the turn, if playerTurn then player moves first otherwise enemy moves first
        playerTurn = (Random.value > 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
