using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{

    public float enemyCurrentHP = 100;
    public float enemyMaxHP = 100;
    public Transform damageText;
    public Transform deathEffect;

    bool doFunction = true;
    bool doOnce = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMasterControl.playerTurn) {
            doFunction = true;
        }

        if (!gameMasterControl.playerTurn && doFunction)
        {
            //TODO enemies turn to act, it needs to choose a character, choose an attack and choose a target
            // pass for now

            doFunction = false;
            StartCoroutine(delayMove());
        }

        if (gameMasterControl.displayDamageDealt) {
            enemyCurrentHP -= gameMasterControl.damageDealt;
            Debug.Log(enemyCurrentHP);
            gameMasterControl.displayDamageDealt = false;
        }

        if(enemyCurrentHP <= 0 && doOnce) {
            Destroy(gameObject);
            Instantiate(deathEffect, gameObject.transform.localPosition, deathEffect.rotation);
            doOnce = false;
        }
    }

    IEnumerator delayMove()
    {
        yield return new WaitForSeconds(2f);

        //TODO: DOES NOT WORK GOOD, player can spam 1 like crazy
        gameMasterControl.damageDealt = 20;
        Instantiate(damageText, new Vector2(-6f, 2.7f), damageText.rotation);
        gameMasterControl.playerTurn = true;
        gameMasterControl.turnTimer++;
    }
}
