using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DailyQuest : MonoBehaviour {
    GameObject Manager;

    public GameObject objective;
    public GameObject description;
    public bool inProcess;
    public int number;
    // Use this for initialization
    void Start () {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        generateQuest();
        inProcess = false;
    }
	
	// Update is called once per frame
	void Update () {
        TimeSpan ts = getTimeSpan();
        float newQuest = (float)ts.TotalMinutes;
        if (newQuest > 1 && inProcess == false)
        {
            inProcess = true;
            generateQuest();
        }
    }

    public void generateQuest()
    {
        number = UnityEngine.Random.Range(1, 2);
       if(number == 1)
       {
          Quest1();
       }  else if (number == 2)
       {
          Quest2();
       }
    }

    void Quest1()
    {
        objective.GetComponent<Text>().text = "[Tasty !]";
        description.GetComponent<Text>().text = "Feed 3 Food to the Chicken";
    }

    void Quest2()
    {
        objective.GetComponent<Text>().text = "[Play With Me]";
        description.GetComponent<Text>().text = "Pat Chicken Head 25 Times";
    }
    
    TimeSpan getTimeSpan()
    {
        return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }
}
