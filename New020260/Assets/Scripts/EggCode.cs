using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCode : MonoBehaviour {

    GameObject Manager;

    // Use this for initialization
    void Start () {
        Manager = GameObject.FindGameObjectWithTag("Manager");
    }

    void OnMouseDown()
    {
        Manager.GetComponent<Manager>().money += 10;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {

        

    }


}
