using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    Vector2 startPos;

    public static float playerCurrentHP = 100;
    public static float playerMaxHP = 100;
    public Transform damageText;
    public Transform deathEffect;

    Vector3 originalPosition;
    public float shakeStrength = 3;
    public float shake = 1;


    public healthBarController healthBar;

    void Start()
    {
        startPos = transform.position;
        healthBar.updatehealthBar(1f);
    }

    private void Awake()
    {
        Camera MainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO : change from input 1 so that a player clicks his way to a spell instead.
        if (Input.GetKeyDown("1") && gameMasterControl.playerTurn) {
            gameMasterControl.damageDealt = 50;
            GetComponent<Rigidbody2D>().position = new Vector2(0, 0);
            GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0);
            StartCoroutine(attackWait());

        }

        if(playerCurrentHP <= 0) {
            Destroy(gameObject);
            Instantiate(deathEffect, gameObject.transform.localPosition, deathEffect.rotation);
        }

        if (gameMasterControl.playerTurn) {
            Debug.Log("PlayerHP : " + playerCurrentHP);
            healthBar.updatehealthBar(playerCurrentHP / 100);
        }
    }

    // Attack animation, using IEnumerators
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

    // Attack animation, using IEnumerators
    IEnumerator moveBack() {
        yield return new WaitForSeconds(0.05f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-25f, 0);
        StartCoroutine(stopgoingBack());
    }

    // Attack animation, using IEnumerators
    IEnumerator attackWait() {

        yield return new WaitForSeconds(1.5f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(25f, 0);
        StartCoroutine(moveBack());

    }

    // Attack animation, using IEnumerators
    IEnumerator stopgoingBack() {
        yield return new WaitForSeconds(0.05f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //StartCoroutine(cameraShake.Shake(.08f, .2f));
        Camera.main.transform.localPosition = originalPosition + (Random.insideUnitSphere * shake);
        shake = Mathf.MoveTowards(shake, 0, Time.deltaTime * shakeStrength);
        if (shake <= 0.5)
        {
            Camera.main.transform.localPosition = originalPosition;
        }
        StartCoroutine(returnPosition());
        Instantiate(damageText, new Vector2(3.36f, 2.75f), damageText.rotation);
        gameMasterControl.displayDamageDealt = true;
    }
}
