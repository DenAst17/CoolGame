using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class StartMenuButtons : MonoBehaviour {
    GameObject set;
    Slider tg;
    private void Awake()
    {
        set = Resources.Load("Settings") as GameObject;
    }
    public void ButtonStart()
    {
        if (FindObjectOfType<Slider>() && FindObjectOfType<Slider>().tag == "jo")
        {
            tg = FindObjectOfType<Slider>();
            Global.difficulty = Convert.ToInt32(tg.value);
        }
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Settings"));
        SceneManager.LoadScene("SelectLevel");
    }
    public void ButtonSettings()
    {
        if (!GameObject.FindGameObjectWithTag("Settings"))
        {
            Canvas ca = FindObjectOfType<Canvas>();
            Instantiate(set,ca.transform);
        }
    }
    public void ButtonExit()
    {
        Application.Quit();
    }
}
