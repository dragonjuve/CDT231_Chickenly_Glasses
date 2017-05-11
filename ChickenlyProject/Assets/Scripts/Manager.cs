using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    [SerializeField]
    public int money;

    public GameObject hungerText;
    public GameObject happinessText;
    public GameObject moneyText;
    public GameObject dayText;
    public GameObject treasureAward;
    public float time = 0.0f;
    int countForQuest1;
    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;
    public GameObject optionPanel;
    public GameObject datePanel;
    public GameObject thenPanel;
    public GameObject dateInput;
    public GameObject thenInput;
    public GameObject collectableMenu;
    //public GameObject dateText;
    float coolDown = 30.00f;
    public GameObject DailyQuest;
    public GameObject youngChicken;
    public GameObject youngAdultChicken;
    public GameObject closeOldChicken;
    public GameObject OldChicken;
    public GameObject pet;
    public GameObject pet2;
    public GameObject pet3;
    public GameObject pet4;
    public GameObject explore;
    bool exploring;
    bool fading = false;
    bool fading2 = false;
    public GameObject ItemPic;
    public GameObject feedFoodPic;
    public GameObject foodPanel;
    public Sprite[] foodIcon;
    public Sprite[] Cosmetics;
    public GameObject foods;
    public Text[] foodAmount;
    public GameObject store;
    public int[] feedValue;
    public int[] price;
    public GameObject[] item;
    bool spawnItem = false;
    Color C;
    

    void Start()
    {
        if (!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetInt("money", money);
        }
        else
        {
            money = PlayerPrefs.GetInt("money");
        }
    }

    void Update () {
        if (pet.activeSelf == true)
        {
            happinessText.GetComponent<Text>().text = pet.GetComponent<Robo>().Happiness.ToString();
            hungerText.GetComponent<Text>().text = pet.GetComponent<Robo>().Hunger.ToString();
        }
        if (pet2.activeSelf == true)
        {
            happinessText.GetComponent<Text>().text = pet2.GetComponent<Robo2>().Happiness.ToString();
            hungerText.GetComponent<Text>().text = pet2.GetComponent<Robo2>().Hunger.ToString();
        }
        if (pet3.activeSelf == true)
        {
            happinessText.GetComponent<Text>().text = pet3.GetComponent<Robo3>().Happiness.ToString();
            hungerText.GetComponent<Text>().text = pet3.GetComponent<Robo3>().Hunger.ToString();
        }
        if (pet4.activeSelf == true)
        {
            happinessText.GetComponent<Text>().text = pet4.GetComponent<Robo4>().Happiness.ToString();
            hungerText.GetComponent<Text>().text = pet4.GetComponent<Robo4>().Hunger.ToString();
        }

        moneyText.GetComponent<Text>().text = money.ToString();
        nameText.GetComponent<Text>().text = PlayerPrefs.GetString("name");

        if (countForQuest1 >= 3)
        {
            treasureAward.SetActive(true);
            countForQuest1 = 0;
            DailyQuest.GetComponent<DailyQuest>().inProcess = false;
            money += 1000;
            DailyQuest.GetComponent<DailyQuest>().generateQuest();
        }

        if (int.Parse(dayText.GetComponent<Text>().text) >= 5) {
            explore.SetActive(true);

        }

        if (explore == true) {
            coolDown -= Time.deltaTime;
        }
        if (coolDown <= 0) {
            exploring = false;
            if (int.Parse(dayText.GetComponent<Text>().text) >= 5 && int.Parse(dayText.GetComponent<Text>().text) < 19)
            {
                youngAdultChicken.SetActive(true);
                if (spawnItem == true) {
                    ItemPic.SetActive(true);
                    RandomItem();
                }
            }
            else if (int.Parse(dayText.GetComponent<Text>().text) >= 19 && int.Parse(dayText.GetComponent<Text>().text) < 49)
            {
                closeOldChicken.SetActive(true);
                if (spawnItem == true)
                {
                    ItemPic.SetActive(true);
                    RandomItem();
                }
            }
            else if (int.Parse(dayText.GetComponent<Text>().text) >= 49)
            {
                OldChicken.SetActive(true);
                if (spawnItem == true)
                {
                    ItemPic.SetActive(true);
                    RandomItem();
                }
            }
            spawnItem = false;
        }

        if (int.Parse(dayText.GetComponent<Text>().text) < 5)
        {
            youngChicken.SetActive(true);
            youngAdultChicken.SetActive(false);
            closeOldChicken.SetActive(false);
            OldChicken.SetActive(false);
        }
        else if(int.Parse(dayText.GetComponent<Text>().text) >= 5 && int.Parse(dayText.GetComponent<Text>().text) < 19 && exploring == false)
        {
            youngChicken.SetActive(false);
            youngAdultChicken.SetActive(true);
            closeOldChicken.SetActive(false);
            OldChicken.SetActive(false);
        }
        else if(int.Parse(dayText.GetComponent<Text>().text) >= 19 && int.Parse(dayText.GetComponent<Text>().text) < 49 && exploring == false)
        {
            youngChicken.SetActive(false);
            youngAdultChicken.SetActive(false);
            closeOldChicken.SetActive(true);
            OldChicken.SetActive(false);
        }

        else if (int.Parse(dayText.GetComponent<Text>().text) >= 49 && exploring == false)
        {
            youngChicken.SetActive(false);
            youngAdultChicken.SetActive(false);
            closeOldChicken.SetActive(false);
            OldChicken.SetActive(true);
        }

        if (fading && feedFoodPic.GetComponent<SpriteRenderer>().color.a > 0)
        {
            float al = feedFoodPic.GetComponent<SpriteRenderer>().color.a;
            al -= 100 * Time.deltaTime;
            Color Co = feedFoodPic.GetComponent<SpriteRenderer>().color;
            feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(Co.r, Co.g, Co.b, (int)al);
            //Debug.Log(feedFoodPic.GetComponent<SpriteRenderer>().color.a);
        }
        else if(fading && feedFoodPic.GetComponent<SpriteRenderer>().color.a <= 0)
        {
            Color Co = feedFoodPic.GetComponent<SpriteRenderer>().color;
            feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(Co.r, Co.g, Co.b, 0);
            fading = false;
            Debug.Log("enD");
        }
    }


    public void triggerNamePanel(bool b)
    {
        namePanel.SetActive(!namePanel.activeInHierarchy);
        if (b)
        {
            nameText.GetComponent<Text>().text = nameInput.GetComponent<InputField>().text;
            PlayerPrefs.SetString("name", nameText.GetComponent<Text>().text);
        }
    }

    public void triggerdailyQuest()
    {
        DailyQuest.SetActive(!DailyQuest.activeInHierarchy);
    }

    public void goExplore() {
        coolDown = 20.0f;
        if (int.Parse(dayText.GetComponent<Text>().text) >= 5 && int.Parse(dayText.GetComponent<Text>().text) < 19)
        {
            youngAdultChicken.SetActive(false);
            exploring = true;
            spawnItem = true;
        }
        else if (int.Parse(dayText.GetComponent<Text>().text) >= 19 && int.Parse(dayText.GetComponent<Text>().text) < 49)
        {
            closeOldChicken.SetActive(false);
            exploring = true;
            spawnItem = true;
        }
        else if (int.Parse(dayText.GetComponent<Text>().text) >= 49)
        {
            OldChicken.SetActive(false);
            exploring = true;
            spawnItem = true;
        }
    }

    public void triggerCollectableMenu() {
        collectableMenu.SetActive(!collectableMenu.activeInHierarchy);
    }

    public void triggerCheat(bool b)
    {
        datePanel.SetActive(!datePanel.activeInHierarchy);
        if (b)
        {
            if(dateInput.GetComponent<InputField>().text != "")
                PlayerPrefs.SetString("firstPlay", dateInput.GetComponent<InputField>().text);
        }
    }

    public void triggerCheat2(bool b)
    {
        thenPanel.SetActive(!thenPanel.activeInHierarchy);
        if (b)
        {
            if (thenInput.GetComponent<InputField>().text != "")
                PlayerPrefs.SetString("then", thenInput.GetComponent<InputField>().text);
            if (pet.activeSelf == true)
            {
                pet.GetComponent<Robo>().updateStatus();
            }
            else if (pet2.activeSelf == true)
            {
                pet2.GetComponent<Robo2>().updateStatus();
            }
            else if (pet3.activeSelf == true) {
                pet3.GetComponent<Robo3>().updateStatus();
            } else if (pet4.activeSelf == true) {
                pet4.GetComponent<Robo4>().updateStatus();
            }
        }
    }

    public void triggerOption(bool b)
    {
        optionPanel.SetActive(!optionPanel.activeInHierarchy);
    }

    public void buttonBahavior(int i)
    {
        switch (i)
        {
            case 0:
            default:
                break;
            case 1:
                store.SetActive(!foodPanel.activeInHierarchy);
                break;
            case 2:
                foodPanel.SetActive(!foodPanel.activeInHierarchy);
                break;
            case 3:
                break;
            case 4:
                pet.GetComponent<Robo>().savePet();
                Application.Quit();
                break;
        }
    }

    void RandomItem()
    {
        int random = UnityEngine.Random.Range(1, 9);
        if (random > 8) {
            random = 8;
        }
        ItemPic.GetComponent<SpriteRenderer>().sprite = Cosmetics[random];
        item[random].GetComponent<Image>().sprite = Cosmetics[random];
    }

    public void selectFood(int i)
    {
        if (DailyQuest.GetComponent<DailyQuest>().number == 1)
            {
                    countForQuest1++;
            }
            int hun = feedValue[i];
        int pay = price[i];
        if (money >= pay)
        {
            money -= pay;
            pet.GetComponent<Robo>().Hunger += hun;
            pet2.GetComponent<Robo2>().Hunger += hun;
            pet3.GetComponent<Robo3>().Hunger += hun;
            pet4.GetComponent<Robo4>().Hunger += hun;

            if (pet.GetComponent<Robo>().Hunger > 100)
            {
                pet.GetComponent<Robo>().Hunger = 100;
            }
            if (pet2.GetComponent<Robo2>().Hunger > 100)
            {
                pet2.GetComponent<Robo2>().Hunger = 100;
            }
            if (pet3.GetComponent<Robo3>().Hunger > 100)
            {
                pet3.GetComponent<Robo3>().Hunger = 100;
            }
            if (pet4.GetComponent<Robo4>().Hunger > 100)
            {
                pet4.GetComponent<Robo4>().Hunger = 100;
            }

            if (money < 0)
                money = 0;

            foodPanel.SetActive(false);
            if (pet.activeSelf == true)
            {
                feedFoodPic.transform.position = new Vector3(pet.transform.position.x, feedFoodPic.transform.position.y, feedFoodPic.transform.position.z);
            }
            else if (pet2.activeSelf == true)
            {
                feedFoodPic.transform.position = new Vector3(pet2.transform.position.x, feedFoodPic.transform.position.y, feedFoodPic.transform.position.z);
            }
            else if (pet3.activeSelf == true)
            {
                feedFoodPic.transform.position = new Vector3(pet3.transform.position.x, feedFoodPic.transform.position.y, feedFoodPic.transform.position.z);
            }
            else if (pet4.activeSelf == true)
            {
                feedFoodPic.transform.position = new Vector3(pet4.transform.position.x, feedFoodPic.transform.position.y, feedFoodPic.transform.position.z);
            }
            feedFoodPic.GetComponent<SpriteRenderer>().sprite = foodIcon[i];
            C = feedFoodPic.GetComponent<SpriteRenderer>().color;
            feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(C.r, C.g, C.b, 255);
            Invoke("fade", 1);

            if (pet.activeSelf == true)
            {
                pet.GetComponent<Animator>().SetBool("walking", false);
                pet.GetComponent<Robo>().idle = false;
                //pet.GetComponent<Robo>().idleCount = 15 / Time.deltaTime;
                pet.GetComponent<Animator>().SetTrigger("eat");
            }
            if (pet2.activeSelf == true)
            {
                pet2.GetComponent<Animator>().SetBool("walking", false);
                pet2.GetComponent<Robo2>().idle = false;
                //pet2.GetComponent<Robo2>().idleCount = 15 / Time.deltaTime;
                pet2.GetComponent<Animator>().SetTrigger("eat");
            }
            if (pet3.activeSelf == true)
            {
                pet3.GetComponent<Animator>().SetBool("walking", false);
                pet3.GetComponent<Robo3>().idle = false;
                //pet3.GetComponent<Robo3>().idleCount = 15 / Time.deltaTime;
                pet3.GetComponent<Animator>().SetTrigger("eat");
            }
            if (pet4.activeSelf == true)
            {
                pet4.GetComponent<Animator>().SetBool("walking", false);
                pet4.GetComponent<Robo4>().idle = false;
               // pet4.GetComponent<Robo4>().idleCount = 15 / Time.deltaTime;
                pet4.GetComponent<Animator>().SetTrigger("eat");
            }

        }        
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("money", money);
    }
    

    public void toggle(GameObject g)
    {
        if (g.activeInHierarchy)
            g.SetActive(false);
    }

    void fade()
    {
        fading = true;
        Debug.Log("fade");
    }
}
