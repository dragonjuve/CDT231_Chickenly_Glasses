using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Robo : MonoBehaviour {

    [SerializeField]
    public int hunger;
    [SerializeField]
    private int happiness;
    [SerializeField]
    public string itsName;
    public GameObject dayText;
    public Animator anim;
    public GameObject manager;
    public GameObject treasureAward;
    public GameObject daily;
    public GameObject Golden;
    int countForQuest2;
    GameObject Manager;
    public GameObject egg;
    private bool serverTime;
    private int clickCount;
    int AGE = 0;
    int dayCount ;
    public int dayCountde ;
    public GameObject dirt;
    bool DEBUG;
    bool goldSpawn;
    public float time = 0.0f;
    public GameObject Playrub;
    public bool idle;
    //public float idleCount;
    float sXwalk;
    bool walkRight;
    public GameObject Smile;

    void Start() {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        if (!PlayerPrefs.HasKey("name"))
        {
            PlayerPrefs.SetString("name", "Chick");
        }
        else
        {
            itsName = PlayerPrefs.GetString("name");
        }

        
        if (!PlayerPrefs.HasKey("firstPlay"))
        {
            PlayerPrefs.SetString("firstPlay", getStringTime());
        }

        if (!PlayerPrefs.HasKey("happiness"))
        {
            PlayerPrefs.SetInt("happiness", happiness);
        }
        else
        {
            happiness = PlayerPrefs.GetInt("happiness");
        }
        if (!PlayerPrefs.HasKey("hunger"))
        {
            PlayerPrefs.SetInt("hunger", hunger);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("hunger");
        }
        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", DateTime.Now.ToString());
        }
        else
        {
            updateStatus();
        }
        idle = true;
        print(PlayerPrefs.GetString("name"));
        StartCoroutine(willWalk());
        StartCoroutine(backToIdle());
        //idleCount = 15 / Time.deltaTime;
        sXwalk = -0.01f;
        walkRight = false;
    }


    void Update() {
        //print(PlayerPrefs.GetString("name"));
      //  print(PlayerPrefs.GetInt("happiness"));
        //print(PlayerPrefs.GetInt("hunger"));
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
                    Playrub.GetComponent<AudioSource>().Play();
                    clickCount++;
                    manager.GetComponent<Manager>().achieveCount[0]++;
                    if (clickCount >= 3)
                    {
                        GameObject smile = (GameObject)Instantiate(Smile, transform.position, transform.rotation);
                        smile.transform.position = new Vector2(transform.position.x, transform.position.y+1.5f);
                        manager.GetComponent<Manager>().achieveCount[5]++;
                        clickCount = 0;
                        updateHappiness(3);
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300.0f));
                        GetComponent<Animator>().SetBool("walking",false);
                        idle = false;              
                        //idleCount = 15 / Time.deltaTime;
                    }
                    
                    if (countForQuest2 >= 25)
                    {
                        treasureAward.SetActive(true);
                        countForQuest2 = 0;
                        daily.GetComponent<DailyQuest>().inProcess = false;
                        Manager.GetComponent<Manager>().money += 500;
                        daily.GetComponent<DailyQuest>().generateQuest();
                    }
                }
                if (hit.transform.gameObject.tag == "GoldenEgg") {
                    Golden.SetActive(false);
                    goldSpawn = false;
                }
            }
        }

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteKey("hunger");
            PlayerPrefs.DeleteKey("happiness");
        }

        if(transform.position.y >= 4.0f)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
        }

        if (GetComponent<Animator>().GetBool("walking"))
        {
            
            
            if (transform.position.x <= 0 && !walkRight)
            {
                sXwalk = 0.01f;
                walkRight = true;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                
            }
            else if(transform.position.x >= 1.5f && walkRight)
            {
                sXwalk = -0.01f;
                walkRight = false;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
            transform.Translate(new Vector3(sXwalk,0,0));
        }
    }



    public void updateStatus()
    {
        TimeSpan ts = getTimeSpan();
        Hunger -= (int)ts.TotalHours * 2;
        if (Hunger < 0)
            Hunger = 0;

        if (Hunger > 100)
        {
            Hunger = 100;
        }

        Happiness -= (100 - Hunger) * (int)ts.TotalHours * 2;

        if (Happiness < 0)
            Happiness = 0;

        if (Happiness > 100)
        {
            Hunger = 100;
        }
        //InvokeRepeating("updateDevice", 0f, 30f);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("happiness", Happiness);
        PlayerPrefs.SetInt("hunger", Hunger);
        PlayerPrefs.SetString("then", getStringTime());
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
        PlayerPrefs.SetInt("hunger",hunger);
        PlayerPrefs.SetInt("happiness",happiness);
    }

    void OnMouseDown()
    {
        if (Golden.activeInHierarchy) {
            Manager.GetComponent<Manager>().money += 100;
            //gameObject.GetComponent<AudioSource>().Play();
            Golden.SetActive(false);
        }
        
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
            if (!idle) {
                idle = true;
                Debug.Log("back to idle");
            }
        }
    }

    

}
