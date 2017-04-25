using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Robo2 : MonoBehaviour
{

    [SerializeField]
    public int hunger;
    [SerializeField]
    private int happiness;
    [SerializeField]
    private string itsName;
    public GameObject dayText;
    public Animator anim;
    public GameObject previousChicken;
    public GameObject treasureAward;
    public GameObject daily;

    int countForQuest3;
    GameObject Manager;
    public GameObject egg;
    private bool serverTime;
    private int clickCount;
    int AGE = 0;
    int dayCount;
    public int dayCountde;
    public GameObject dirt;
    bool DEBUG;

    public float time = 0.0f;

    void Start()
    {
        //PlayerPrefs.SetString("then", "03/30/2017 06:00:00");
        //Debug.Log(getTimeSpan().TotalHours);
        Manager = GameObject.FindGameObjectWithTag("Manager");
        updateStatus();
        if (!PlayerPrefs.HasKey("name"))
            PlayerPrefs.SetString("name", "Cracker");
        itsName = PlayerPrefs.GetString("name");

        TimeSpan sinceBegin = getTimeSpan();
        dayCount = previousChicken.GetComponent<Robo>().dayCountde;
        if (sinceBegin.TotalHours > 72.0)
        {
            AGE = 1;
        }

        if (PlayerPrefs.HasKey("lastBath"))
        {
            if (PlayerPrefs.GetInt("lastBath") > 12)
            {
                dirt.SetActive(true);
            }
        }


        GetComponent<Animator>().SetInteger("age", AGE);

    }


    void Update()
    {
        if (!DEBUG)
        {
            dayText.GetComponent<Text>().text = dayCount.ToString();
        }
        else
        {
            dayText.GetComponent<Text>().text = dayCountde.ToString();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {
                if (hit.transform.gameObject.tag == "Pet")
                {
                    if (daily.GetComponent<DailyQuest>().number == 3 || daily.GetComponent<DailyQuest>().number == 4)
                    {
                        countForQuest3++;
                    }
                    clickCount++;
                    if (clickCount >= 3)
                    {
                        clickCount = 0;
                        updateHappiness(1);
                    }

                    if (countForQuest3 >= 25)
                    {
                        treasureAward.SetActive(true);
                        countForQuest3 = 0;
                        daily.GetComponent<DailyQuest>().inProcess = false;
                        Manager.GetComponent<Manager>().money += 1000;
                        daily.GetComponent<DailyQuest>().generateQuest();
                    }
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.S))
        {

            PlayerPrefs.SetString("then", "03/30/2017 06:00:00");
            //Debug.Log(getStringTime().ToString());
            updateStatus();

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(getStringTime().ToString());
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(getTimeSpan().ToString());
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteKey("hunger");
            PlayerPrefs.DeleteKey("happiness");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            dayCountde = dayCount;
            DEBUG = !DEBUG;
        }
        if ((Input.GetKeyDown(KeyCode.U)) && (DEBUG))
        {
            dayCountde++;
            Debug.Log(dayCountde);
        }
    }

    void updateStatus()
    {

        TimeSpan ts = getTimeSpan();
        float produceEgg = (float)ts.TotalHours;
        Debug.Log(produceEgg);
        for (float i = produceEgg; i >= 0; i -= 10)
        {
            GameObject EGG = (GameObject)Instantiate(egg, transform.position, transform.rotation);
            EGG.transform.position = new Vector2(UnityEngine.Random.Range(-2.9f, 2.0f), -3f);
            if (i == 10)
            {
                break;
            }
        }


        Hunger -= (int)ts.TotalHours * 2;
        if (Hunger < 0)
            Hunger = 0;

        Happiness -= (100 - Hunger) * (int)ts.TotalHours / 5;

        if (Happiness < 0)
            Happiness = 0;

        //Debug.Log(getTimeSpan().ToString());
        //Debug.Log(getTimeSpan().TotalHours);

        //if (serverTime)
        //    updateServer();
        //else
        //    InvokeRepeating("updateDevice",0f,30f);
    }

    void updateServer()
    {

    }

    void updateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    public int Hunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int Happiness
    {
        get { return happiness; }
        set { happiness = value; }
    }



    public string Name
    {
        get { return itsName; }
        set { itsName = value; }
    }

    TimeSpan getTimeSpan()
    {
        if (serverTime)
            return new TimeSpan();
        else
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    public void updateHappiness(int i)
    {
        gameObject.GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetTrigger("isHappy");
        Happiness += i;
        if (Happiness > 100)
            Happiness = 100;

    }

    public void savePet()
    {
        if (!serverTime)
            updateDevice();
        PlayerPrefs.SetInt("hunger", hunger);
        PlayerPrefs.SetInt("happiness", happiness);
    }
}
