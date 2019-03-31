using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{

    public float enemyCurrentHP = 100;
    public float enemyMaxHP = 100;
    public float enemyAttackPower = 35;
    public Transform damageText;
    public Transform deathEffect;
    int attackingTarget;

    //TODO there's gotta be a better way than this
    public static bool attackonlyOnce = true;
    bool doOnce = true;

    public healthBarController healthBar;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!gameMasterControl.playerTurn ) {
            doFunction = true;
        }*/

        if (!gameMasterControl.playerTurn && attackonlyOnce &&((int) gameMasterControl.positionIdentifier == (int) transform.position.x))
        {
                //TODO enemies turn to act, it needs to choose a character, choose an attack and choose a target
                // pass for now
                attackonlyOnce = false;
                Debug.Log("posIdentifier = " + (int)gameMasterControl.positionIdentifier);
                Debug.Log("enemy : " + (int)transform.localPosition.x + "attacks");
                StartCoroutine(delayMove());
        }

        if (gameMasterControl.displayDamageDealt) {
            enemyCurrentHP -= gameMasterControl.damageDealt;
            gameMasterControl.displayDamageDealt = false;
        }

        if(enemyCurrentHP <= 0 && doOnce) {
            Destroy(gameObject);
            Instantiate(deathEffect, gameObject.transform.localPosition, deathEffect.rotation);
            doOnce = false;
        }

        if (!gameMasterControl.playerTurn) {
            Debug.Log("EnemyHP : " + enemyCurrentHP);
            healthBar.updatehealthBar(enemyCurrentHP / 100);
        }
    }

    IEnumerator delayMove()
    {
        yield return new WaitForSeconds(2f);

        //Randoms a number between 1,2,3
        attackingTarget = Random.Range(1, 4);

        switch (attackingTarget)
        {
            case (1):
               // Debug.Log("Attacking player 1");
                break;

            case (2):
               // Debug.Log("Attack player 2");
                break;

            case (3):
               // Debug.Log("Attacking player 3");
                break;        
        }

        gameMasterControl.damageDealt = enemyAttackPower;
        playerControl.playerCurrentHP -= enemyAttackPower;
        Instantiate(damageText, new Vector2(-6f, 2.7f), damageText.rotation);
        gameMasterControl.playerTurn = true;
        gameMasterControl.turnTimer++;
        attackonlyOnce = true;
    }
}
