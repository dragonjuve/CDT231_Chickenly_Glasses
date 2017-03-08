using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Robo : MonoBehaviour {

    [SerializeField]
    private int hunger;
    [SerializeField]
    private int happiness;
    [SerializeField]
    private string itsName;

    public GameObject egg;
    private bool serverTime;
    private int clickCount;

    void Start() {
        //PlayerPrefs.SetString("then", "02/17/2017 06:00:00");
        //Debug.Log(getTimeSpan().TotalHours);
        updateStatus();

        if (!PlayerPrefs.HasKey("name"))
            PlayerPrefs.SetString("name", "Cracker");
        itsName = PlayerPrefs.GetString("name");
    }


    void Update() {

        GetComponent<Animator>().SetBool("jump", gameObject.transform.position.y > -1);

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {
                if (hit.transform.gameObject.tag == "Pet")
                {
                    clickCount++;
                    if(clickCount >= 3)
                    {
                        clickCount = 0;
                        updateHappiness(1);
                        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
                    }
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetString("then", "03/07/2017 06:00:00");
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
    }

    void updateStatus()
    {
        /*if (!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("hunger", hunger);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("hunger");
        }

        if (!PlayerPrefs.HasKey("happiness"))
        {
            happiness = 100;
            PlayerPrefs.SetInt("happiness", happiness);
        }
        else
        {
            happiness = PlayerPrefs.GetInt("happiness");
        }
        */
        TimeSpan ts = getTimeSpan();
        float produceEgg = (float)ts.TotalSeconds;
        Debug.Log(produceEgg);
        for (float i = produceEgg; i >= 0; i -= 10)
        {
            
            GameObject EGG = (GameObject)Instantiate(egg, transform.position, transform.rotation);
            EGG.transform.position = new Vector2(UnityEngine.Random.Range(-2.9f, 2.0f), -2f);
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

        if (serverTime)
            updateServer();
        else
            InvokeRepeating("updateDevice",0f,30f);
    }

    void updateServer()
    {

    }

    void updateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    public int Hunger {
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
        Happiness += i;
        if (Happiness > 100)
            Happiness = 100;
    }

    public void savePet()
    {
        if (!serverTime)
            updateDevice();
        PlayerPrefs.SetInt("hunger",hunger);
        PlayerPrefs.SetInt("happiness",happiness);
    }
}
