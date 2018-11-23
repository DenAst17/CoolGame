using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn : MonoBehaviour {
    public void Blue()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
            Hero.colorbutton = "blue";
    }
    public void Green()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
            Hero.colorbutton = "green";
    }
    public void Red()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
            Hero.colorbutton = "red";
    }
    public void MoneysPlus()
    {
        Hero.coins += 5;
    }
    public void BulletsPlus()
    {
        Hero.bullets += 5;
    }
}
