using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnDisplay : MonoBehaviour
{

    public Text whoPlays;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMasterControl.playerTurn) {
            whoPlays.text = "Player turn";
        }
        else {
            whoPlays.text = "Enemy turn";
        }
    }
}
