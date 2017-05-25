using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
public class option : MonoBehaviour {

    public GameObject[] BGM;
    public GameObject BGM_On;
    public GameObject BGM_Off;
    public GameObject BG;
    public Sprite[] BGsprite;
    public GameObject dayText;
    public GameObject hungerText;
    public GameObject happinessText;
    public GameObject moneyText;
    public GameObject Manager;
    public GameObject musicOption;
    float coolDownmusicOption = 0.3f;
    int id = 0;
    int id2 = 0;
    // Use this for initialization

    void Start() {
        Manager = GameObject.FindGameObjectWithTag("Manager");
    }

    void update() {

    }
    public void Quit() {
        musicOption.GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void EnableSound() {
        musicOption.GetComponent<AudioSource>().Play();
        if (BGM[0].GetComponent<AudioSource>().isPlaying || BGM[1].GetComponent<AudioSource>().isPlaying || BGM[2].GetComponent<AudioSource>().isPlaying)
        {
            BGM[0].GetComponent<AudioSource>().Stop();
            BGM[1].GetComponent<AudioSource>().Stop();
            BGM[2].GetComponent<AudioSource>().Stop();
            BGM_On.SetActive(false);
            BGM_Off.SetActive(true);
            PlayerPrefs.SetInt("SaveBGM", 0);
        }
        else {
            BGM[0].GetComponent<AudioSource>().Play();
            BGM[1].GetComponent<AudioSource>().Play();
            BGM[2].GetComponent<AudioSource>().Play();
            BGM_On.SetActive(true);
            BGM_Off.SetActive(false);
            PlayerPrefs.SetInt("SaveBGM", 1);
        }
        
    }

    public void BGchange(bool next) {
        musicOption.GetComponent<AudioSource>().Play();
        if (next)
        {
            id++;
            if (id >= BGsprite.Length)
            {
                id = 0;
            }
        }

        else
        {
            id--;
            if (id < 0)
            {
                id = BGsprite.Length - 1;
            }
        }

        
        BG.GetComponent<SpriteRenderer>().sprite = BGsprite[id];
        PlayerPrefs.SetInt("BackGroundSave", id);

    }

    public void changeBackgroundMusic(bool next) {
        musicOption.GetComponent<AudioSource>().Play();
        if (next)
        {
            id2++;
            if (id2 >= BGM.Length)
            {
                id2 = 0;
            }
        }
        else
        {
            id2--;
            if (id2 < BGM.Length)
            {
                id2 = BGM.Length - 1;
            }
        }
        for (int i = 0; i < BGM.Length; i++) {
            if (i == id2)
            {
                BGM[i].SetActive(true);
            }
            else {
                BGM[i].SetActive(false);
            }
        }
        PlayerPrefs.SetInt("BackGroundMusic", id2);
    }

    public void Reset() {
        musicOption.GetComponent<AudioSource>().Play();
        coolDownmusicOption = 0.3f;
        PlayerPrefs.DeleteKey("RibbonNow");
        /*PlayerPrefs.SetInt("hunger", 0);
        PlayerPrefs.SetInt("happiness", 0);
        hungerText.GetComponent<Text>().text = PlayerPrefs.GetInt("hunger").ToString();
        happinessText.GetComponent<Text>().text = PlayerPrefs.GetInt("happiness").ToString(); 
        hungerText.GetComponent<Text>().text = "0";
        happinessText.GetComponent<Text>().text = "0";
        Manager.GetComponent<Manager>().money = 0;
        PlayerPrefs.SetInt("money", 0);
        moneyText.GetComponent<Text>().text = PlayerPrefs.GetInt("money").ToString();*/
        PlayerPrefs.DeleteKey("CosmeticSave1");
        PlayerPrefs.DeleteKey("CosmeticSave2");
        PlayerPrefs.DeleteKey("CosmeticSave3");
        PlayerPrefs.DeleteKey("CosmeticSave4");
        PlayerPrefs.DeleteKey("CosmeticSave5");
        PlayerPrefs.DeleteKey("CosmeticSave6");
        PlayerPrefs.DeleteKey("CosmeticSave7");
        PlayerPrefs.DeleteKey("CosmeticSave8");
        PlayerPrefs.DeleteKey("CosmeticSave9");
        PlayerPrefs.DeleteKey("CosmeticSave10");
        PlayerPrefs.DeleteKey("CosmeticSave11");
        PlayerPrefs.DeleteKey("CosmeticSave12");
        PlayerPrefs.DeleteKey("RibbonNow");
        PlayerPrefs.DeleteKey("HatNow");
        PlayerPrefs.DeleteKey("CapNow");
        PlayerPrefs.SetString("name", "Chick");
        PlayerPrefs.SetString("firstPlay", DateTime.Now.ToString());
        dayText.GetComponent<Text>().text = "1";
    }


}
