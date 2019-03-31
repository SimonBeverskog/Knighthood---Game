using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarController : MonoBehaviour
{

    public Transform bar;

    void Start()
    {
        //bar = transform.Find("Bar");
    }

    public void updatehealthBar(float sizeNormalized) {

        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
