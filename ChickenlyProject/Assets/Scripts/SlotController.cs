using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMEnter()
    {
        transform.parent.GetComponent<InventoryController>().selectedSlot = this.transform;
    }

    public void OnMExit()
    {
        transform.parent.GetComponent<InventoryController>().selectedSlot = null;
    }
}
