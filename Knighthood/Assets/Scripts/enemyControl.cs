using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{

    bool doFunction = true;
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
    }

    IEnumerator delayMove()
    {
        yield return new WaitForSeconds(2f);

        //TODO: DOES NOT WORK GOOD, player can spam 1 like crazy
        gameMasterControl.playerTurn = true;
        gameMasterControl.turnTimer++;
    }
}
