using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Global : MonoBehaviour {
    private Slider tg;
    public static int difficulty = 1;
    public static int deads = 0;
    public static bool[] lvlsop = new bool[16];
    public static int levelscomp = 0;
    private void Awake()
    {
        lvlsop[0] = true;
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectOfType<Slider>() && FindObjectOfType<Slider>().tag == "jo")
        {
            tg = FindObjectOfType<Slider>();
            difficulty = Convert.ToInt32(tg.value);
        }
    }
}
