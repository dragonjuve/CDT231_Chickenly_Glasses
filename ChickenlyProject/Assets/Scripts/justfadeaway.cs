using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justfadeaway : MonoBehaviour {
    float coolDown = 2.00f;
    // Use this for initialization
    void Start () {
		
	}

    void OnMouseDown()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            gameObject.SetActive(false);
            coolDown = 2.00f;
        }
    }
}
