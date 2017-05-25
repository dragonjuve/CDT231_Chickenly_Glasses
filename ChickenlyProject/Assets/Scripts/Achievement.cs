using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Achievement : MonoBehaviour {

    public GameObject[] AchivementText;
    public GameObject[] AchivementImage;
    public Sprite SuccessfulImage;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (int.Parse(AchivementText[0].GetComponent<Text>().text) == 9001) {
            AchivementImage[0].GetComponent<Image>().sprite = SuccessfulImage;
            
        }
        if (int.Parse(AchivementText[1].GetComponent<Text>().text) >= 10000)
        {
            AchivementImage[1].GetComponent<Image>().sprite = SuccessfulImage;
            
        }
        if (int.Parse(AchivementText[2].GetComponent<Text>().text) == 150)
        {
            AchivementImage[2].GetComponent<Image>().sprite = SuccessfulImage;
            
        }
        if (int.Parse(AchivementText[3].GetComponent<Text>().text) == 200)
        {
            AchivementImage[3].GetComponent<Image>().sprite = SuccessfulImage;
            
        }
        if (int.Parse(AchivementText[4].GetComponent<Text>().text) == 12)
        {
            AchivementImage[4].GetComponent<Image>().sprite = SuccessfulImage;
            
        }
        if (int.Parse(AchivementText[5].GetComponent<Text>().text) == 100)
        {
            AchivementImage[5].GetComponent<Image>().sprite = SuccessfulImage;
        }
    }
}
