using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileMove : MonoBehaviour {
    float coolDown = 1.30f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        coolDown -= Time.deltaTime;
        transform.Translate(Vector3.up * Time.deltaTime);
        if (coolDown <= 0)
        {
            coolDown = 1.30f;
            Destroy(gameObject);
        }
    }
}
