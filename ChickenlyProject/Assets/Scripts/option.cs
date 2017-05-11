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
    public GameObject BG;
    public Sprite[] BGsprite;
    public GameObject dayText;
    int id = 0;
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

    public void BGchange(bool next) {
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
        
    }

    public void Reset() {
        PlayerPrefs.SetString("firstPlay", DateTime.Now.ToString());
        dayText.GetComponent<Text>().text = "1";
    }


}
