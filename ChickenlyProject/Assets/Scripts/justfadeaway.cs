using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justfadeaway : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseDown()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
