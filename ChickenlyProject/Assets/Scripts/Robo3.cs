using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Robo3 : MonoBehaviour
{

    [SerializeField]
    public int hunger;
    [SerializeField]
    private int happiness;
    [SerializeField]
    public string itsName;
    public GameObject dayText;
    public Animator anim;
    public GameObject previousChicken;
    public GameObject treasureAward;
    public GameObject daily;
    public GameObject Golden;
    bool goldSpawn;
    int countForQuest2;
    GameObject Manager;
    public GameObject egg;
    private bool serverTime;
    private int clickCount;
    int AGE = 0;
    int dayCount;
    public int dayCountde;
    public GameObject dirt;
    bool DEBUG;

    public bool idle;
    //public float idleCount;
    float sXwalk;
    bool walkRight;

    public float time = 0.0f;

    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        updateStatus();
        if (!PlayerPrefs.HasKey("name"))
        {
            PlayerPrefs.SetString("name", "Cracker");
        }
        else
        {
            itsName = PlayerPrefs.GetString("name");
        }

        idle = true;
        StartCoroutine(willWalk());
        StartCoroutine(backToIdle());
        //idleCount = 15 / Time.deltaTime;
        sXwalk = -0.01f;
        walkRight = false;
        updateStatus();
    }


    void Update()
    {
        if ((DateTime.Now.Hour >= 5 && DateTime.Now.Hour <= 7) && !goldSpawn)
        {
            Golden.SetActive(true);
            goldSpawn = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {
                if (hit.transform.gameObject.tag == "Pet")
                {
                    if (daily.GetComponent<DailyQuest>().number == 2)
                    {
                        countForQuest2++;
                    }
                    clickCount++;
                    if (clickCount >= 3)
                    {
                        clickCount = 0;
                        updateHappiness(1);
                        GetComponent<Animator>().SetBool("walking", false);
                        idle = false;
                        //idleCount = 15 / Time.deltaTime;
                    }

                    if (countForQuest2 >= 25)
                    {
                        treasureAward.SetActive(true);
                        countForQuest2 = 0;
                        daily.GetComponent<DailyQuest>().inProcess = false;
                        Manager.GetComponent<Manager>().money += 1000;
                        daily.GetComponent<DailyQuest>().generateQuest();
                    }
                }
                if (hit.transform.gameObject.tag == "GoldenEgg")
                {
                    Golden.SetActive(false);
                    goldSpawn = false;
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.S))
        {

            PlayerPrefs.SetString("then", "03/29/2017 06:00:00");
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
        /*if (Input.GetKeyDown(KeyCode.I))
        {
            dayCountde = dayCount;
            DEBUG = !DEBUG;
        }
        if ((Input.GetKeyDown(KeyCode.U)) && (DEBUG))
        {
            dayCountde++;
            Debug.Log(dayCountde);
        }*/
        //idleCount--;

        //if (idleCount < 0)
        //{
        //    idleCount = 0;
        //}

        //if (idleCount == 0 && !GetComponent<Animator>().GetBool("walking"))
        //{
        //    GetComponent<Animator>().SetBool("walking", true);
        //}

        if (GetComponent<Animator>().GetBool("walking"))
        {

            if (transform.position.x <= 0 && !walkRight)
            {
                sXwalk = 0.01f;
                walkRight = true;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (transform.position.x >= 1.5f && walkRight)
            {
                sXwalk = -0.01f;
                walkRight = false;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); ;
            }
            transform.Translate(new Vector3(sXwalk, 0, 0));
        }
    }

    public void updateStatus()
    {
        int time = 0;
        TimeSpan ts = getTimeSpan();
        /*float getDirty = (float)ts.TotalHours;

        if (getDirty > 4.0f)
        {
            dirt.SetActive(true);
        }*/
        float produceEgg = (float)ts.TotalHours / 15.0f;
        //Debug.Log(produceEgg);
        for (float i = produceEgg; i >= 0; i -= 10)
        {
            GameObject EGG = (GameObject)Instantiate(egg, transform.position, transform.rotation);
            EGG.transform.position = new Vector2(UnityEngine.Random.Range(-2.9f, 2.0f), -3f);
            time++;
            if (time == 10)
            {
                break;
            }
        }


        Hunger -= (int)ts.TotalHours * 2;
        if (Hunger < 0)
            Hunger = 0;

        if (Hunger > 100)
        {
            Hunger = 100;
        }

        Happiness -= (100 - Hunger) * (int)ts.TotalHours / 5;

        if (Happiness < 0)
            Happiness = 0;

        if (Happiness > 100)
        {
            Hunger = 100;
        }

        //Debug.Log(getTimeSpan().ToString());
        //Debug.Log(getTimeSpan().TotalHours);

        //if (serverTime)
        //    updateServer();
        //else
        //    InvokeRepeating("updateDevice",0f,30f);
        InvokeRepeating("updateDevice", 0f, 30f);
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

    IEnumerator willWalk()
    {
        while (true)
        {
            if (!GetComponent<Animator>().GetBool("walking"))
            {
                int duration = UnityEngine.Random.Range(5, 16);
                for (float i = 0; i < duration; i += 0.1f)
                {
                    if (!idle)
                    {
                        duration = UnityEngine.Random.Range(5, 16);
                        i = 0;
                    }
                    yield return new WaitForSeconds(0.1f);
                }
                Debug.Log("now walk");
                GetComponent<Animator>().SetBool("walking", true);
            }
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator backToIdle()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            if (!idle)
            {
                idle = true;
                Debug.Log("back to idle");
            }
        }
    }
}
