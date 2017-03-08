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
    

    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;

    public GameObject pet;
    
    public GameObject foodPanel;
    public Sprite[] foodIcon;
    public GameObject foods;

    public GameObject store;

    void Update () {
        happinessText.GetComponent<Text>().text = pet.GetComponent<Robo>().Happiness.ToString();
        hungerText.GetComponent<Text>().text = pet.GetComponent<Robo>().Hunger.ToString();
        moneyText.GetComponent<Text>().text = money.ToString();
        nameText.GetComponent<Text>().text = pet.GetComponent<Robo>().Name;
    }

    public void triggerNamePanel(bool b)
    {
        namePanel.SetActive(!namePanel.activeInHierarchy);
        if (b)
        {
            pet.GetComponent<Robo>().Name = nameInput.GetComponent<InputField>().text;
            PlayerPrefs.SetString("name", pet.GetComponent<Robo>().Name);
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
        pet.GetComponent<Robo>().Hunger += 1;
        if (pet.GetComponent<Robo>().Hunger > 100)
            pet.GetComponent<Robo>().Hunger = 100;
        toggle(foodPanel);
        foods.SetActive(true);
    }


    public void toggle(GameObject g)
    {
        if (g.activeInHierarchy)
            g.SetActive(false);
    }
}
