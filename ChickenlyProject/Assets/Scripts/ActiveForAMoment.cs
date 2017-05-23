using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveForAMoment : MonoBehaviour {
    float coolDown = 5.0f;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            gameObject.SetActive(false);
            coolDown = 5.00f;
        }
    }
}
