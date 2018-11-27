using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Global : MonoBehaviour {
    private Slider tg;
    public static int difficulty = 1;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectOfType<Slider>() && FindObjectOfType<Slider>().tag == "jo")
        {
            tg = FindObjectOfType<Slider>();
            difficulty = Convert.ToInt32(tg.value);
        }
    }
}
