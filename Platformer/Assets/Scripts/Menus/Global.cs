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
    public static bool Respawns = true;
    public static int respawns = 0;
    public static int shoots = 0;
    public static int hpplus = 0;
    public static int fieldsplus = 0;
    public static int monsterskill = 0;
    public static int jumps = 0;
    public static int coinsplus = 0;
    public static int bustersplus = 0;
    public static int levelsfinished = 0;
    public static int globalscore = 0;
    public static int globalstars = 0;
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
    private void Update()
    {
        Debug.Log(difficulty);
    }
}
