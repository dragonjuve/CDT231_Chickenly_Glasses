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

    int countForQuest2;
    int countForQuest1;
    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;
    public GameObject optionPanel;
    public GameObject datePanel;
    public GameObject thenPanel;
    public GameObject dateInput;
    public GameObject thenInput;
    //public GameObject dateText;

    public GameObject DailyQuest;
    public GameObject youngChicken;
    public GameObject youngAdultChicken;
    public GameObject closeOldChicken;
    public GameObject OldChicken;
    public GameObject pet;
    public GameObject pet2;
    public GameObject pet3;
    public GameObject pet4;
    bool fading = false;
    public GameObject feedFoodPic;
    public GameObject foodPanel;
    public Sprite[] foodIcon;
    public GameObject foods;
    public Text[] foodAmount;
    public GameObject store;
    public int[] feedValue;
    public int[] price;

    Color C;
    

    void Start()
    {
        //PlayerPrefs.SetString("then","05/10/2017 06:00:00");
        //PlayerPrefs.SetString("firstPlay","05/04/2017 06:00:00");
        //time = 0;

    }

    void Update () {
        //print(PlayerPrefs.GetString("firstPlay"));
        if(pet.activeSelf == true)
        {
            happinessText.GetComponent<Text>().text = pet.GetComponent<Robo>().Happiness.ToString();
            hungerText.GetComponent<Text>().text = pet.GetComponent<Robo>().Hunger.ToString();
            //nameText.GetComponent<Text>().text = pet.GetComponent<Robo>().itsName;
        }
        if (pet2.activeSelf == true)
        {
            happinessText.GetComponent<Text>().text = pet2.GetComponent<Robo2>().Happiness.ToString();
            hungerText.GetComponent<Text>().text = pet2.GetComponent<Robo2>().Hunger.ToString();
            //nameText.GetComponent<Text>().text = pet2.GetComponent<Robo2>().itsName;
        }
        if (pet3.activeSelf == true)
        {
            happinessText.GetComponent<Text>().text = pet3.GetComponent<Robo3>().Happiness.ToString();
            hungerText.GetComponent<Text>().text = pet3.GetComponent<Robo3>().Hunger.ToString();
            //nameText.GetComponent<Text>().text = pet3.GetComponent<Robo3>().itsName;
        }
        if (pet4.activeSelf == true)
        {
            happinessText.GetComponent<Text>().text = pet4.GetComponent<Robo4>().Happiness.ToString();
            hungerText.GetComponent<Text>().text = pet4.GetComponent<Robo4>().Hunger.ToString();
           // nameText.GetComponent<Text>().text = pet4.GetComponent<Robo4>().itsName;
        }

        moneyText.GetComponent<Text>().text = money.ToString();
        nameText.GetComponent<Text>().text = PlayerPrefs.GetString("name");
        if (countForQuest2 >= 2)
        {
            countForQuest2 = 0;
            treasureAward.SetActive(true);
            DailyQuest.GetComponent<DailyQuest>().inProcess = false;
            money += 1000;
            DailyQuest.GetComponent<DailyQuest>().generateQuest();
        }
        if (countForQuest1 >= 2)
        {
            treasureAward.SetActive(true);
            countForQuest1 = 0;
            DailyQuest.GetComponent<DailyQuest>().inProcess = false;
            money += 1000;
            DailyQuest.GetComponent<DailyQuest>().generateQuest();
        }
        if (int.Parse(dayText.GetComponent<Text>().text) < 5)
        {
            youngChicken.SetActive(true);
            youngAdultChicken.SetActive(false);
            closeOldChicken.SetActive(false);
            OldChicken.SetActive(false);
        }
        else if(int.Parse(dayText.GetComponent<Text>().text) >= 5 && int.Parse(dayText.GetComponent<Text>().text) < 19)
        {
            youngChicken.SetActive(false);
            youngAdultChicken.SetActive(true);
            closeOldChicken.SetActive(false);
            OldChicken.SetActive(false);
        }
        else if(int.Parse(dayText.GetComponent<Text>().text) >= 19 && int.Parse(dayText.GetComponent<Text>().text) < 49){
            youngChicken.SetActive(false);
            youngAdultChicken.SetActive(false);
            closeOldChicken.SetActive(true);
            OldChicken.SetActive(false);
        }

        else if (int.Parse(dayText.GetComponent<Text>().text) >= 49)
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

    public void triggerdailyQuest(bool b)
    {
        DailyQuest.SetActive(!DailyQuest.activeInHierarchy);
        if (b)
        {
        }
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
        if (b)
        {
        }
           
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

        if (DailyQuest.GetComponent<DailyQuest>().number == 1 || DailyQuest.GetComponent<DailyQuest>().number == 1)
        {
            countForQuest1++;
        }

        
    }

    //public void selectFood2(int i)
    //{
    //    pet.GetComponent<Robo>().Hunger += 3;
    //    pet2.GetComponent<Robo2>().Hunger += 3;
    //    pet3.GetComponent<Robo3>().Hunger += 3;
    //    pet4.GetComponent<Robo4>().Hunger += 3;
    //    if (pet.GetComponent<Robo>().Hunger > 100)
    //    {
    //        pet.GetComponent<Robo>().Hunger = 100;
    //    }
    //    if (pet2.GetComponent<Robo2>().Hunger > 100)
    //    {
    //        pet2.GetComponent<Robo2>().Hunger = 100;
    //    }
    //    if (pet3.GetComponent<Robo3>().Hunger > 100)
    //    {
    //        pet3.GetComponent<Robo3>().Hunger = 100;
    //    }
    //    if (pet4.GetComponent<Robo4>().Hunger > 100)
    //    {
    //        pet4.GetComponent<Robo4>().Hunger = 100;
    //    }

    //    if (foodAmt[1] > 0)
    //    {
    //        foodAmt[1]--;
    //        feedFoodPic.GetComponent<SpriteRenderer>().sprite = foodIcon[1];
    //        Color C = feedFoodPic.GetComponent<SpriteRenderer>().color;
    //        feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(C.r, C.g, C.b, 255);
    //        Invoke("fade", 1);
    //    }

    //    if (DailyQuest.GetComponent<DailyQuest>().number == 1)
    //    {
    //        countForQuest1++;
    //    }

        
    //}

    //public void selectFood3(int i)
    //{
    //    pet.GetComponent<Robo>().Hunger += 5;
    //    pet2.GetComponent<Robo2>().Hunger += 5;
    //    pet3.GetComponent<Robo3>().Hunger += 5;
    //    pet4.GetComponent<Robo4>().Hunger += 5;
    //    if (pet.GetComponent<Robo>().Hunger > 100)
    //    {
    //        pet.GetComponent<Robo>().Hunger = 100;
    //    }
    //    if (pet2.GetComponent<Robo2>().Hunger > 100)
    //    {
    //        pet2.GetComponent<Robo2>().Hunger = 100;
    //    }
    //    if (pet3.GetComponent<Robo3>().Hunger > 100)
    //    {
    //        pet3.GetComponent<Robo3>().Hunger = 100;
    //    }
    //    if (pet4.GetComponent<Robo4>().Hunger > 100)
    //    {
    //        pet4.GetComponent<Robo4>().Hunger = 100;
    //    }

    //    if (foodAmt[2] > 0)
    //    {
    //        foodAmt[2]--;
    //        feedFoodPic.GetComponent<SpriteRenderer>().sprite = foodIcon[2];
    //        Color C = feedFoodPic.GetComponent<SpriteRenderer>().color;
    //        feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(C.r, C.g, C.b, 255);
    //        Invoke("fade", 1);
    //    }

    //    if (DailyQuest.GetComponent<DailyQuest>().number == 1)
    //    {
    //        countForQuest1++;
    //    }
    //}

    //public void selectFood4(int i)
    //{
    //    pet.GetComponent<Robo>().Hunger += 7;
    //    pet2.GetComponent<Robo2>().Hunger += 7;
    //    pet3.GetComponent<Robo3>().Hunger += 7;
    //    pet4.GetComponent<Robo4>().Hunger += 7;
    //    if (pet.GetComponent<Robo>().Hunger > 100)
    //    {
    //        pet.GetComponent<Robo>().Hunger = 100;
    //    }
    //    if (pet2.GetComponent<Robo2>().Hunger > 100)
    //    {
    //        pet2.GetComponent<Robo2>().Hunger = 100;
    //    }
    //    if (pet3.GetComponent<Robo3>().Hunger > 100)
    //    {
    //        pet3.GetComponent<Robo3>().Hunger = 100;
    //    }
    //    if (pet4.GetComponent<Robo4>().Hunger > 100)
    //    {
    //        pet4.GetComponent<Robo4>().Hunger = 100;
    //    }

    //    if (foodAmt[3] > 0)
    //    {
    //        foodAmt[3]--;
    //        feedFoodPic.GetComponent<SpriteRenderer>().sprite = foodIcon[3];
    //        Color C = feedFoodPic.GetComponent<SpriteRenderer>().color;
    //        feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(C.r, C.g, C.b, 255);
    //        Invoke("fade", 1);
    //    }

    //    if (DailyQuest.GetComponent<DailyQuest>().number == 1)
    //    {
    //        countForQuest1++;
    //    }
    //}

    //public void selectFood5(int i)
    //{
    //    pet.GetComponent<Robo>().Hunger += 9;
    //    pet2.GetComponent<Robo2>().Hunger += 9;
    //    pet3.GetComponent<Robo3>().Hunger += 9;
    //    pet4.GetComponent<Robo4>().Hunger += 9;

    //    if (pet.GetComponent<Robo>().Hunger > 100)
    //    {
    //        pet.GetComponent<Robo>().Hunger = 100;
    //    }
    //    if (pet2.GetComponent<Robo2>().Hunger > 100)
    //    {
    //        pet2.GetComponent<Robo2>().Hunger = 100;
    //    }
    //    if (pet3.GetComponent<Robo3>().Hunger > 100)
    //    {
    //        pet3.GetComponent<Robo3>().Hunger = 100;
    //    }
    //    if (pet4.GetComponent<Robo4>().Hunger > 100)
    //    {
    //        pet4.GetComponent<Robo4>().Hunger = 100;
    //    }

    //    if (foodAmt[4] > 0)
    //    {
    //        foodAmt[4]--;
    //        feedFoodPic.GetComponent<SpriteRenderer>().sprite = foodIcon[4];
    //        Color C = feedFoodPic.GetComponent<SpriteRenderer>().color;
    //        feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(C.r, C.g, C.b, 255);
    //        Invoke("fade", 1);
    //    }
    //}

    //public void selectFood6(int i)
    //{
    //    pet.GetComponent<Robo>().Hunger += 11;
    //    pet2.GetComponent<Robo2>().Hunger += 11;
    //    pet3.GetComponent<Robo3>().Hunger += 11;
    //    pet4.GetComponent<Robo4>().Hunger += 11;
    //    if (pet.GetComponent<Robo>().Hunger > 100)
    //    {
    //        pet.GetComponent<Robo>().Hunger = 100;
    //    }
    //    if (pet2.GetComponent<Robo2>().Hunger > 100)
    //    {
    //        pet2.GetComponent<Robo2>().Hunger = 100;
    //    }
    //    if (pet3.GetComponent<Robo3>().Hunger > 100)
    //    {
    //        pet3.GetComponent<Robo3>().Hunger = 100;
    //    }
    //    if (pet4.GetComponent<Robo4>().Hunger > 100)
    //    {
    //        pet4.GetComponent<Robo4>().Hunger = 100;
    //    }

    //    if (foodAmt[5] > 0)
    //    {
    //        foodAmt[5]--;
    //        feedFoodPic.GetComponent<SpriteRenderer>().sprite = foodIcon[5];
    //        Color C = feedFoodPic.GetComponent<SpriteRenderer>().color;
    //        feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(C.r, C.g, C.b, 255);
    //        Invoke("fade", 1);
    //    }

    //    if (DailyQuest.GetComponent<DailyQuest>().number == 1)
    //    {
    //        countForQuest1++;
    //    }
    //}

    //public void selectFood7(int i)
    //{
    //    pet.GetComponent<Robo>().Hunger += 13;
    //    pet2.GetComponent<Robo2>().Hunger += 13;
    //    pet3.GetComponent<Robo3>().Hunger += 13;
    //    pet4.GetComponent<Robo4>().Hunger += 13;
    //    if (pet.GetComponent<Robo>().Hunger > 100)
    //    {
    //        pet.GetComponent<Robo>().Hunger = 100;
    //    }
    //    if (pet2.GetComponent<Robo2>().Hunger > 100)
    //    {
    //        pet2.GetComponent<Robo2>().Hunger = 100;
    //    }
    //    if (pet3.GetComponent<Robo3>().Hunger > 100)
    //    {
    //        pet3.GetComponent<Robo3>().Hunger = 100;
    //    }
    //    if (pet4.GetComponent<Robo4>().Hunger > 100)
    //    {
    //        pet4.GetComponent<Robo4>().Hunger = 100;
    //    }

    //    if (foodAmt[6] > 0)
    //    {
    //        foodAmt[6]--;
    //        feedFoodPic.GetComponent<SpriteRenderer>().sprite = foodIcon[6];
    //        Color C = feedFoodPic.GetComponent<SpriteRenderer>().color;
    //        feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(C.r, C.g, C.b, 255);
    //        Invoke("fade", 1);
    //    }

    //    if (DailyQuest.GetComponent<DailyQuest>().number == 1)
    //    {
    //        countForQuest1++;
    //    }
    //}

    //public void selectFood8(int i)
    //{
    //    pet.GetComponent<Robo>().Hunger += 15;
    //    pet2.GetComponent<Robo2>().Hunger += 15;
    //    pet3.GetComponent<Robo3>().Hunger += 15;
    //    pet4.GetComponent<Robo4>().Hunger += 15;
    //    if (pet.GetComponent<Robo>().Hunger > 100)
    //    {
    //        pet.GetComponent<Robo>().Hunger = 100;
    //    }
    //    if (pet2.GetComponent<Robo2>().Hunger > 100)
    //    {
    //        pet2.GetComponent<Robo2>().Hunger = 100;
    //    }
    //    if (pet3.GetComponent<Robo3>().Hunger > 100)
    //    {
    //        pet3.GetComponent<Robo3>().Hunger = 100;
    //    }
    //    if (pet4.GetComponent<Robo4>().Hunger > 100)
    //    {
    //        pet4.GetComponent<Robo4>().Hunger = 100;
    //    }

    //    if (foodAmt[7] > 0)
    //    {
    //        foodAmt[7]--;
    //        feedFoodPic.GetComponent<SpriteRenderer>().sprite = foodIcon[7];
    //        Color C = feedFoodPic.GetComponent<SpriteRenderer>().color;
    //        feedFoodPic.GetComponent<SpriteRenderer>().color = new Color(C.r, C.g, C.b, 255);
    //        Invoke("fade", 1);
    //    }

    //    if (DailyQuest.GetComponent<DailyQuest>().number == 1)
    //    {
    //        countForQuest1++;
    //    }
    //}
    //public void selectInStore1(int i)
    //{
        
    //    if (money >= 10)
    //        money -= 10;
    //    if (money < 0)
    //        money = 0;
    //    else
    //        foodAmt[0]++;
    //    if (DailyQuest.GetComponent<DailyQuest>().number == 2)
    //    {
    //        countForQuest2++;
    //    }
       
    //}

    //public void selectInStore2(int i)
    //{
    //    if (money >= 20)
    //        money -= 20;
    //    if (money < 0)
    //        money = 0;
    //    else
    //        foodAmt[1]++;
    //    if (DailyQuest.GetComponent<DailyQuest>().number == 2)
    //    {
    //        countForQuest2++;
    //    }
    //}

    //public void selectInStore3(int i)
    //{
    //    money -= 30;
    //    if (money < 0)
    //        money = 0;
    //    else
    //        foodAmt[2]++;
    //    if (DailyQuest.GetComponent<DailyQuest>().number == 2)
    //    {
    //        countForQuest2++;
    //    }
    //}

    //public void selectInStore4(int i)
    //{
    //    money -= 40;
    //    if (money < 0)
    //        money = 0;
    //    else
    //        foodAmt[3]++;
    //    if (DailyQuest.GetComponent<DailyQuest>().number == 2)
    //    {
    //        countForQuest2++;
    //    }
    //}

    //public void selectInStore5(int i)
    //{
    //    money -= 50;
    //    if (money < 0)
    //        money = 0;
    //    else
    //        foodAmt[4]++;
    //    if (DailyQuest.GetComponent<DailyQuest>().number == 2)
    //    {
    //        countForQuest2++;
    //    }
    //}

    //public void selectInStore6(int i)
    //{
    //    money -= 60;
    //    if (money < 0)
    //        money = 0;
    //    else
    //        foodAmt[5]++;

    //    if (DailyQuest.GetComponent<DailyQuest>().number == 2)
    //    {
    //        countForQuest2++;
    //    }
    //}

    //public void selectInStore7(int i)
    //{
    //    money -= 70;
    //    if (money < 0)
    //        money = 0;
    //    else
    //        foodAmt[6]++;

    //    if (DailyQuest.GetComponent<DailyQuest>().number == 2)
    //    {
    //        countForQuest2++;
    //    }
    //}

    //public void selectInStore8(int i)
    //{
    //    money -= 80;
    //    if (money < 0)
    //        money = 0;
    //    else
    //        foodAmt[7]++;

    //    if (DailyQuest.GetComponent<DailyQuest>().number == 2)
    //    {
    //        countForQuest2++;
    //    }
    //}

   /* public void dailyQuest()
    {
        DailyQuest.SetActive(true);
    }*/

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
