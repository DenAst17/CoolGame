using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class StartMenuButtons : MonoBehaviour {
    GameObject set;
    GameObject go;
    Slider tg;
    private void Awake()
    {
        set = Resources.Load("Settings") as GameObject;
    }
    public void ButtonStart()
    {
        if (GameObject.FindGameObjectWithTag("jo"))
        {
            go = GameObject.FindGameObjectWithTag("jo");
            tg = go.GetComponent<Slider>();
            if (go.tag == "jo")
                Global.difficulty = Convert.ToInt32(tg.value); // YEAH!
            GameObject.Destroy(GameObject.FindGameObjectWithTag("Settings"));
        }
        SceneManager.LoadScene("SelectLevel");
    }
    public void ButtonSettings()
    {
        if (!GameObject.FindGameObjectWithTag("Settings"))
        {
            Canvas ca = FindObjectOfType<Canvas>();
            Instantiate(set,ca.transform);
            go = GameObject.FindGameObjectWithTag("jo");
            tg = go.GetComponent<Slider>();
            tg.value = Global.difficulty;
        }
    }
    public void ButtonExit()
    {
        Application.Quit();
    }
}
