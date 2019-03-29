using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    Vector2 startPos;
    public cameraShake cameraShake;
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
            StartCoroutine(attackWait());

        }
    }

    IEnumerator returnPosition() {
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().position = new Vector2(startPos.x, startPos.y);
        GetComponent<Transform>().localScale = new Vector3(0.4f, 0.4f, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //TODO: DOES NOT WORK GOOD, player can spam 1 like crazy

        //after turn is up, pass it over to the enemy and increase the round-timer
        gameMasterControl.playerTurn = false;
        gameMasterControl.turnTimer++;
    }

    IEnumerator moveBack() {
        yield return new WaitForSeconds(0.05f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-25f, 0);
        StartCoroutine(stopgoingBack());
    }

    IEnumerator attackWait() {

        yield return new WaitForSeconds(1.5f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(25f, 0);
        StartCoroutine(moveBack());

    }

    IEnumerator stopgoingBack() {
        yield return new WaitForSeconds(0.05f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        StartCoroutine(cameraShake.Shake(.08f, .2f));
        StartCoroutine(returnPosition());
    }
}
