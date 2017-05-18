using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearing : MonoBehaviour {
    public GameObject DailyQuest;
    GameObject Manager;
    public GameObject treasure;
    static int countForQuest3;
    // Use this for initialization
    void Start () {
        Manager = GameObject.FindGameObjectWithTag("Manager");
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
        gameObject.SetActive(false);
        if (DailyQuest.GetComponent<DailyQuest>().number == 3)
        {
            countForQuest3++;
        }
        if (countForQuest3 == 3) {
            treasure.SetActive(true);
            countForQuest3 = 0;
            DailyQuest.GetComponent<DailyQuest>().inProcess = false;
            Manager.GetComponent<Manager>().money += 30;
            DailyQuest.GetComponent<DailyQuest>().generateQuest();
        }
    }
}
