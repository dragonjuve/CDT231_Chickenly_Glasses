using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearing : MonoBehaviour {

    public GameObject Dirty;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void willbegone()
    {
        Invoke("gone", 3);
    }

    void gone()
    {
        Dirty.SetActive(false);
        gameObject.SetActive(false);
    }
}
