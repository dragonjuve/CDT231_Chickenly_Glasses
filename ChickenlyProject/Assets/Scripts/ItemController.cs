using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
    GameObject Pet;
    // Use this for initialization
    void Start () {
        Pet = GameObject.FindGameObjectWithTag("Pet");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnMEnter()
    {
        //transform.parent.parent.GetComponent<InventoryController>().selectedItem = this.transform;\
        //Pet.GetComponent<Robo>().Hunger += 10;
    }

    public void OnMExit()
    {
        //transform.parent.parent.GetComponent<InventoryController>().selectedItem = null;
    }
}
