using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DailyQuest : MonoBehaviour {
    GameObject Manager;
    public GameObject objective;
    public GameObject description;
    public GameObject QuestPicReal;
    
    public bool inProcess;
    public int number;
    public Sprite[] QuestPicSelect;
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
        number = UnityEngine.Random.Range(1, 5);
        if (number == 1)
        {
            Quest1();
        }
        else if (number == 2)
        {
            Quest2();
        }
        else if (number == 3)
        {
            Quest3();
        }
        else {
            Quest4();
        }
    }

    void Quest1()
    {
        objective.GetComponent<Text>().text = "[Tasty !]";
        description.GetComponent<Text>().text = "Feed 3 Food to the Chicken";
        QuestPicReal.GetComponent<Image>().sprite = QuestPicSelect[0];
    }

    void Quest2()
    {
        objective.GetComponent<Text>().text = "[Play With Me]";
        description.GetComponent<Text>().text = "Pat Chicken Head 25 Times";
        QuestPicReal.GetComponent<Image>().sprite = QuestPicSelect[1];
    }

    void Quest3()
    {
        objective.GetComponent<Text>().text = "[Stay Clean!]";
        description.GetComponent<Text>().text = "Wash Your Chicken 3 Times";
    }

    void Quest4()
    {
        objective.GetComponent<Text>().text = "[Is Something There?]";
        description.GetComponent<Text>().text = "Explore And Gather 1 Collectible";
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
