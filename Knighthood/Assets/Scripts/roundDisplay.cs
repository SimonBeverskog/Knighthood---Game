using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundDisplay : MonoBehaviour
{
    public Text roundCount;
    // Start is called before the first frame update
    void Start()
    {
        //At the start we can safely set the turntimer to 1 always
        //TODO right now we use 1.00001f since mathf.round rounds to closest even number and not upwards at 0.5f
        gameMasterControl.turnTimer = 1.00001f;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the roundtimer based on the variable gameMaster keeps track of
        roundCount.text = "Round : " + Mathf.Round(gameMasterControl.turnTimer/2).ToString();
    }
}
