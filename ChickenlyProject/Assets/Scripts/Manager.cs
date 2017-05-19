﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    int countForQuest4;
    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;
    public GameObject waitPanel;
    public GameObject waitText;
    public GameObject optionPanel;
    public GameObject datePanel;
    public GameObject thenPanel;
    public GameObject dateInput;
    public GameObject thenInput;
    public GameObject collectableMenu;
    public GameObject collect;
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
    bool shutforamoment = false;
    bool exploring;
    bool fading = false;
    bool fading2 = false;
    public GameObject ItemPic;
    public GameObject feedFoodPic;
    public GameObject foodPanel;
    public Sprite[] foodIcon;
    public Sprite[] Cosmetics;
    static bool[] CosmeticSave = {false, false, false, false, false, false};
    public GameObject foods;
    public Text[] foodAmount;
    public GameObject store;
    public int[] feedValue;
    public int[] price;
    public GameObject[] item;
    public GameObject music1;
    float coolDownmusic1 = 1.0f;
    public GameObject BG;
    public Sprite[] BGsprite;
    public GameObject music2;
    public GameObject music3;
    public GameObject music4;
    float coolDownmusic4 = 0.5f;
    bool spawnItem = false;
    float rarityhelp = 0;
    int ribbonKey;
    public GameObject BGM;
    public GameObject BGM_On;
    public GameObject BGM_Off;
    Color C;
    

    void Start()
    {
        if (PlayerPrefs.HasKey("SaveBGM")) {
            if (PlayerPrefs.GetInt("SaveBGM") == 1)
            {
                BGM.GetComponent<AudioSource>().Play();
                BGM_On.SetActive(true);
                BGM_Off.SetActive(false);
            }
            else {
                BGM.GetComponent<AudioSource>().Stop();
                BGM_On.SetActive(false);
                BGM_Off.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("BackGroundSave"))
        {
            BG.GetComponent<SpriteRenderer>().sprite = BGsprite[PlayerPrefs.GetInt("BackGroundSave")];
        }
        if (!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetInt("money", money);
        }
        else
        {
            money = PlayerPrefs.GetInt("money");
        }

        foreach(GameObject cosm in item)
        {
            cosm.GetComponent<Button>().interactable = false;
        }

        if (PlayerPrefs.HasKey("CosmeticSave1"))
        {
            item[0].GetComponent<Image>().sprite = Cosmetics[0];
            item[0].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave2"))
        {
            item[1].GetComponent<Image>().sprite = Cosmetics[1];
            item[1].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave3"))
        {
            item[2].GetComponent<Image>().sprite = Cosmetics[2];
            item[2].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave4"))
        {
            item[3].GetComponent<Image>().sprite = Cosmetics[3];
            item[3].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave5"))
        {
            item[4].GetComponent<Image>().sprite = Cosmetics[4];
            item[4].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave6"))
        {
            item[5].GetComponent<Image>().sprite = Cosmetics[5];
            item[5].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave7"))
        {
            item[6].GetComponent<Image>().sprite = Cosmetics[6];
            item[6].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave8"))
        {
            item[7].GetComponent<Image>().sprite = Cosmetics[7];
            item[7].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave9"))
        {
            item[8].GetComponent<Image>().sprite = Cosmetics[8];
            item[8].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave10"))
        {
            item[9].GetComponent<Image>().sprite = Cosmetics[9];
            item[9].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave11"))
        {
            item[10].GetComponent<Image>().sprite = Cosmetics[10];
            item[10].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("CosmeticSave12"))
        {
            item[11].GetComponent<Image>().sprite = Cosmetics[11];
            item[11].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("RibbonNow"))
        {
            ribbonKey = PlayerPrefs.GetInt("RibbonNow");
            if (ribbonKey >= 0)
            {
                if (pet2.activeSelf == true)
                {
                    pet2.transform.Find("YoungAdult_Body").Find("Cosmetic_Ribbon").GetComponent<SpriteRenderer>().sprite = Cosmetics[ribbonKey];
                }
                if (pet3.activeSelf == true)
                {
                    pet3.transform.Find("AdultChicken_torso").Find("Cosmetic_Ribbon").GetComponent<SpriteRenderer>().sprite = Cosmetics[ribbonKey];
                }
                if (pet4.activeSelf == true)
                {
                    pet4.transform.Find("OldChicken_Body").Find("Cosmetic_Ribbon").GetComponent<SpriteRenderer>().sprite = Cosmetics[ribbonKey];
                }
            }
        }

    }

    void Update () {
        print(dayText);
        coolDownmusic4 -= Time.deltaTime;
        if (coolDownmusic4 <= 0)
        {
            music4.SetActive(false);
            coolDownmusic4 = 0.5f;
        }
        coolDownmusic1 -= Time.deltaTime;
        if (coolDownmusic1 <= 0) {
            music1.SetActive(false);
            coolDownmusic1 = 1.0f;
        }
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
        waitText.GetComponent<Text>().text = ((int)coolDown).ToString();
        if (countForQuest1 >= 3)
        {
            treasureAward.SetActive(true);
            countForQuest1 = 0;
            DailyQuest.GetComponent<DailyQuest>().inProcess = false;
            money += 50;
            DailyQuest.GetComponent<DailyQuest>().generateQuest();
            moneyText.GetComponent<Text>().text = money.ToString();
        }
        if (countForQuest4 >= 1)
        {
            treasureAward.SetActive(true);
            countForQuest4 = 0;
            DailyQuest.GetComponent<DailyQuest>().inProcess = false;
            money += 50;
            DailyQuest.GetComponent<DailyQuest>().generateQuest();
            moneyText.GetComponent<Text>().text = money.ToString();
        }

        if (int.Parse(dayText.GetComponent<Text>().text) >= 5 && shutforamoment == false)
        {
            explore.SetActive(true);
        }

        if (int.Parse(dayText.GetComponent<Text>().text) >= 5)
        {
            collect.SetActive(true);
        }

        if (int.Parse(dayText.GetComponent<Text>().text) < 5) {
            explore.SetActive(false);
            collect.SetActive(false);
        }

        if (explore == true) {
            coolDown -= Time.deltaTime;
        }
        if (coolDown <= 0 && pet.activeSelf != true) {
            music2.SetActive(false);
            music3.SetActive(true);
            exploring = false;
            shutforamoment = false;
            explore.SetActive(true);
            if (int.Parse(dayText.GetComponent<Text>().text) >= 5 && int.Parse(dayText.GetComponent<Text>().text) < 19)
            {
                if (DailyQuest.GetComponent<DailyQuest>().number > 3)
                {
                    countForQuest4++;
                }
                youngAdultChicken.SetActive(true);
                waitPanel.SetActive(false);
                if (spawnItem == true) {
                    ItemPic.SetActive(true);
                    RandomItem();
                }
            }
            else if (int.Parse(dayText.GetComponent<Text>().text) >= 19 && int.Parse(dayText.GetComponent<Text>().text) < 49)
            {
                if (DailyQuest.GetComponent<DailyQuest>().number > 3)
                {
                    countForQuest4++;
                }
                closeOldChicken.SetActive(true);
                waitPanel.SetActive(false);
                if (spawnItem == true)
                {
                    ItemPic.SetActive(true);
                    RandomItem();
                }
            }
            else if (int.Parse(dayText.GetComponent<Text>().text) >= 49)
            {
                if (DailyQuest.GetComponent<DailyQuest>().number > 3)
                {
                    countForQuest4++;
                }
                OldChicken.SetActive(true);
                waitPanel.SetActive(false);
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
        music4.SetActive(true);
        namePanel.SetActive(!namePanel.activeInHierarchy);
        if (b)
        {
            nameText.GetComponent<Text>().text = nameInput.GetComponent<InputField>().text;
            PlayerPrefs.SetString("name", nameText.GetComponent<Text>().text);
        }
    }

    public void triggerdailyQuest()
    {
        music4.SetActive(true);
        DailyQuest.SetActive(!DailyQuest.activeInHierarchy);
    }

    public void goExplore() {
        music2.SetActive(true);
        music3.SetActive(false);
        coolDown = 20.0f;
        shutforamoment = true;
        explore.SetActive(false);
        if (!youngChicken.activeInHierarchy)
            waitPanel.SetActive(true);
        
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
        music4.SetActive(true);
    }

    public void triggerCheat(bool b)
    {
        datePanel.SetActive(!datePanel.activeInHierarchy);
        if (b)
        {
            if(dateInput.GetComponent<InputField>().text != "")
                PlayerPrefs.SetString("firstPlay", dateInput.GetComponent<InputField>().text);
        }
        else
        {
            DateTime changes = Convert.ToDateTime(PlayerPrefs.GetString("firstPlay"));
            int days = int.Parse(datePanel.transform.Find("Amount").GetComponent<Text>().text);
            
            changes = changes.AddDays(-days);
            datePanel.transform.Find("Amount").GetComponent<Text>().text = "0";
            PlayerPrefs.SetString("firstPlay", changes.Month + "/" + changes.Day + "/" + changes.Year + " " + changes.Hour + ":" + changes.Minute + ":" + changes.Second);
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
        else
        {
            DateTime changes = Convert.ToDateTime(PlayerPrefs.GetString("then"));
            int hours = int.Parse(thenPanel.transform.Find("Amount").GetComponent<Text>().text);
            print(changes.Hour);
            changes = changes.AddHours(hours);
            print(changes.Hour);
            thenPanel.transform.Find("Amount").GetComponent<Text>().text = "0";
            PlayerPrefs.SetString("then", changes.Month + "/" + changes.Day + "/" + changes.Year + " " + changes.Hour + ":" + changes.Minute + ":" + changes.Second);
            if (pet.activeSelf == true)
            {
                pet.GetComponent<Robo>().updateStatus();
            }
            else if (pet2.activeSelf == true)
            {
                pet2.GetComponent<Robo2>().updateStatus();
            }
            else if (pet3.activeSelf == true)
            {
                pet3.GetComponent<Robo3>().updateStatus();
            }
            else if (pet4.activeSelf == true)
            {
                pet4.GetComponent<Robo4>().updateStatus();
            }
        }
    }

    public void ChangeInDays(int value)
    {
        int days = int.Parse(datePanel.transform.Find("Amount").GetComponent<Text>().text);
        days = days + value;
        datePanel.transform.Find("Amount").GetComponent<Text>().text = days.ToString();
    }

    public void ChangeInHours(int value)
    {
        int hours = int.Parse(thenPanel.transform.Find("Amount").GetComponent<Text>().text);
        hours = hours + value;
        thenPanel.transform.Find("Amount").GetComponent<Text>().text = hours.ToString();
    }



    public void triggerOption(bool b)
    {
        music4.SetActive(true);
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
        int rarity = UnityEngine.Random.Range(1, 17);
        rarity += (int)rarityhelp;
        if (rarity > 17)
        {
            rarity = 17;
        }
        if (rarity >= 1 && rarity <= 6)
        {
            int random = UnityEngine.Random.Range(0, 5);
            if (random > 4)
            {
                random = 4;
            }
            ItemPic.GetComponent<SpriteRenderer>().sprite = Cosmetics[random];
            item[random].GetComponent<Image>().sprite = Cosmetics[random];
            if (random == 0)
            {
                PlayerPrefs.SetInt("CosmeticSave1", random);
            }
            else if (random == 1)
            {
                PlayerPrefs.SetInt("CosmeticSave2", random);
            }
            else if (random == 2)
            {
                PlayerPrefs.SetInt("CosmeticSave3", random);
            }
            else if (random == 3)
            {
                PlayerPrefs.SetInt("CosmeticSave4", random);
            }
            else if (random == 4)
            {
                PlayerPrefs.SetInt("CosmeticSave5", random);
            }
        }
        else if (rarity >= 7 && rarity <= 12)
        {
            int random = UnityEngine.Random.Range(5, 9);
            if (random > 8)
            {
                random = 8;
            }
            ItemPic.GetComponent<SpriteRenderer>().sprite = Cosmetics[random];
            item[random].GetComponent<Image>().sprite = Cosmetics[random];
            if (random == 5)
            {
                PlayerPrefs.SetInt("CosmeticSave6", random);
            }
            else if (random == 6)
            {
                PlayerPrefs.SetInt("CosmeticSave7", random);
            }
            else if (random == 7)
            {
                PlayerPrefs.SetInt("CosmeticSave8", random);
            }
            else if (random == 8)
            {
                PlayerPrefs.SetInt("CosmeticSave9", random);
            }
        }
        else if (rarity >= 13 && rarity <= 16)
        {
            int random = UnityEngine.Random.Range(9, 11);
            if (random > 10)
            {
                random = 10;
            }
            ItemPic.GetComponent<SpriteRenderer>().sprite = Cosmetics[random];
            item[random].GetComponent<Image>().sprite = Cosmetics[random];
            if (random == 9)
            {
                PlayerPrefs.SetInt("CosmeticSave10", random);
            }
            else if (random == 10)
            {
                PlayerPrefs.SetInt("CosmeticSave11", random);
            }
        }
        else {
            ItemPic.GetComponent<SpriteRenderer>().sprite = Cosmetics[11];
            item[11].GetComponent<Image>().sprite = Cosmetics[11];
            PlayerPrefs.SetInt("CosmeticSave12", 11);
        }
        rarityhelp = 0;
    }

    public void selectFood(int i)
    {
        music1.SetActive(true);
        coolDownmusic1 = 1.0f;
        if (DailyQuest.GetComponent<DailyQuest>().number == 1)
            {
                    countForQuest1++;
            }
            int hun = feedValue[i];
        int pay = price[i];
        if (money >= pay)
        {
            money -= pay;
            moneyText.GetComponent<Text>().text = money.ToString();
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

            if (money < 0) {
                money = 0;
                moneyText.GetComponent<Text>().text = money.ToString();
            }
                


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
            if (i == 3)
            {
                rarityhelp += 0.25f;
                feedFoodPic.transform.localScale = new Vector3(0.1f, 0.1f, 0);
            }
            else if (i == 5)
            {
                rarityhelp += 0.75f;
                feedFoodPic.transform.localScale = new Vector3(0.175f, 0.1f, 0);
            }
            else if (i == 4) {
                rarityhelp += 0.5f;
                feedFoodPic.transform.localScale = new Vector3(0.175f, 0.1f, 0);
            } else if (i == 6) {
                rarityhelp += 1.25f;
                feedFoodPic.transform.localScale = new Vector3(0.1f, 0.1f, 0);
            } else if (i == 7) {
                rarityhelp += 1.5f;
                feedFoodPic.transform.localScale = new Vector3(0.175f, 0.1f, 0);
            }
            else
            {
                feedFoodPic.transform.localScale = new Vector3(0.2530704f, 0.0530704f, 0);
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
        PlayerPrefs.SetInt("RibbonNow", ribbonKey);
    }
    

    public void wear(int i)
    {
        if(i < 0)
        {
            if (pet2.activeSelf == true)
            {
                pet2.transform.Find("YoungAdult_Body").Find("Cosmetic_Ribbon").GetComponent<SpriteRenderer>().sprite = null;

            }
            if (pet3.activeSelf == true)
            {
                pet3.transform.Find("AdultChicken_torso").Find("Cosmetic_Ribbon").GetComponent<SpriteRenderer>().sprite = null;
            }
            if (pet4.activeSelf == true)
            {
                pet4.transform.Find("OldChicken_Body").Find("Cosmetic_Ribbon").GetComponent<SpriteRenderer>().sprite = null;
            }
            ribbonKey = -1;
            return;
        }
        if(pet2.activeSelf == true)
        {
            pet2.transform.Find("YoungAdult_Body").Find("Cosmetic_Ribbon").GetComponent<SpriteRenderer>().sprite = Cosmetics[i];
        }
        if (pet3.activeSelf == true)
        {
            pet3.transform.Find("AdultChicken_torso").Find("Cosmetic_Ribbon").GetComponent<SpriteRenderer>().sprite = Cosmetics[i];
        }
        if (pet4.activeSelf == true)
        {
            pet4.transform.Find("OldChicken_Body").Find("Cosmetic_Ribbon").GetComponent<SpriteRenderer>().sprite = Cosmetics[i];
        }
        ribbonKey = i;
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
