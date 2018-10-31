using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn : MonoBehaviour {
    public void Blue()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            Hero.colorbutton = "blue";
        }
        else
        {
            
        }
    }
    public void Green()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            Hero.colorbutton = "green";
        }
        else
        {
            
        }
    }
    public void Red()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            Hero.colorbutton = "red";
        }
        else
        {
            
        }
    }
}
