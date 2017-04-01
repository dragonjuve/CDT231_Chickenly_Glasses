using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCode : MonoBehaviour
{

    GameObject Manager;
    //public GameObject EggMusic;
    float coolDown = 0.25f;
    bool startCount = false;
    // Use this for initialization
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
    }

    void OnMouseDown()
    {
        Manager.GetComponent<Manager>().money += 10;
        gameObject.GetComponent<AudioSource>().Play();
        startCount = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (startCount == true)
        {
            coolDown -= Time.deltaTime;
            Debug.Log(coolDown);
        }
        if (coolDown <= 0)
        {
            startCount = false;
            coolDown = 0.25f;
            Destroy(gameObject);
        }
    }


}
