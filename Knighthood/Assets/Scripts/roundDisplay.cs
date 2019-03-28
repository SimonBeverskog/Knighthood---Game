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
        gameMasterControl.turnTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the roundtimer based on the variable gameMaster keeps track of
        roundCount.text = "Round : " + gameMasterControl.turnTimer.ToString();
    }
}
