using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMasterControl : MonoBehaviour
{
    //float instead of int to allow it to be divided by two and rounded
    public static float turnTimer = 1.0f;
    public static bool playerTurn;

    public static float damageDealt = 0;
    public static bool displayDamageDealt = false;


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
