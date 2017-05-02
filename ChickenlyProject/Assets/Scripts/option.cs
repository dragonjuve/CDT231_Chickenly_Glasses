using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
public class option : MonoBehaviour {

    public GameObject BGM;
    public GameObject BGM_On;
    public GameObject BGM_Off;
    public GameObject BG1;
    public GameObject BG2;
    public GameObject dayText;
    // Use this for initialization
    public void Quit() {
        Application.Quit();
    }

    public void EnableSound() {
        if (BGM.GetComponent<AudioSource>().isPlaying)
        {
            BGM.GetComponent<AudioSource>().Stop();
            BGM_On.SetActive(false);
            BGM_Off.SetActive(true);
        }
        else {
            BGM.GetComponent<AudioSource>().Play();
            BGM_On.SetActive(true);
            BGM_Off.SetActive(false);
        }
        
    }

    public void BGchange() {
        if (BG1.activeSelf == true)
        {
            BG1.SetActive(false);
            BG2.SetActive(true);
        }
        else {
            BG2.SetActive(false);
            BG1.SetActive(true);
        }
    }

    public void Reset() {
        PlayerPrefs.SetString("firstPlay", DateTime.Now.ToString());
        dayText.GetComponent<Text>().text = "1";
    }


}
