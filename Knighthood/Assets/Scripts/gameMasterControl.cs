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

    //Player location variables
    public Transform player_character;
    public Transform player_loc1;

    //Enemy location variables
    public Transform basic_enemy;
    public Transform enemy_loc1;
    public Transform enemy_loc2;
    public Transform enemy_loc3;

    public static float positionIdentifier;


    void Start()
    {
        //Randoms who starts the turn, if playerTurn then player moves first otherwise enemy moves first
        playerTurn = (Random.value > 0.5f);

        //Spawn player
        Instantiate(player_character, player_loc1.localPosition, player_character.rotation);

        //Spawn enemies
        Instantiate(basic_enemy, enemy_loc1.localPosition, basic_enemy.rotation);
        Instantiate(basic_enemy, enemy_loc2.localPosition, basic_enemy.rotation);
        Instantiate(basic_enemy, enemy_loc3.localPosition, basic_enemy.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        //Its the enemies turn to attack, choose who will attack
        if (!playerTurn && enemyControl.attackonlyOnce) {
            int whoAttacks = Random.Range(1, 4);
            switch (whoAttacks) {

                //Attack with enemy 1 (enemy closest to the middle)
                case (1):
                    positionIdentifier = enemy_loc1.localPosition.x;
                    break;

                //Attack with enemy 2 (middle enemy)
                case (2):
                    positionIdentifier = enemy_loc2.localPosition.x;
                    break;

                //Attack with enemy 3 (furthest to the right)       
                case (3):
                    positionIdentifier = enemy_loc3.localPosition.x;
                    break;
            }
        }
    }
}
