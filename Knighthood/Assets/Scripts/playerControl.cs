using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO : change from input 1 so that a player clicks his way to a spell instead.
        if (Input.GetKeyDown("1") && gameMasterControl.playerTurn) {

            GetComponent<Rigidbody2D>().position = new Vector2(0, 0);
            GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0);

            StartCoroutine(returnPosition());

            //After attack pass over turn and increase roundcount
        
        }
    }

    IEnumerator returnPosition() {
        yield return new WaitForSeconds(2f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().position = new Vector2(startPos.x, startPos.y);
        GetComponent<Transform>().localScale = new Vector3(0.4f, 0.4f, 0);

        //TODO: DOES NOT WORK GOOD, player can spam 1 like crazy
        gameMasterControl.playerTurn = false;
        gameMasterControl.turnTimer++;
    }
}
