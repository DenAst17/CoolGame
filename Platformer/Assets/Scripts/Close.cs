using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Close : MonoBehaviour {
    Slider tg;
    public void Closed()
    {
        if (FindObjectOfType<Slider>() && FindObjectOfType<Slider>().tag == "jo")
        {
            tg = FindObjectOfType<Slider>();
            Global.difficulty = Convert.ToInt32(tg.value);
        }
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Settings"));
    }
}
