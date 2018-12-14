using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProporties : MonoBehaviour {
    [SerializeField]
    public int FieldsPlus = 1;
    [SerializeField]
    public string ThisLevelName;
    [SerializeField]
    public int ThisLevel = 1;
    [SerializeField]
    public string NextLevel = "SelectLevel";
    [SerializeField]
    public int StartFields1 = 2;
    [SerializeField]
    public int StartFields2 = 2;
    [SerializeField]
    public int StartFields3 = 2;
    [SerializeField]
    public int StartFields4 = 2;
    [SerializeField]
    public int StartFields5 = 2;
    [SerializeField]
    public float StartHP = 100;
    [SerializeField]
    public int StartCoins = 0;
    [SerializeField]
    public int StartBullets1 = 10;
    [SerializeField]
    public int StartBullets2 = 10;
    [SerializeField]
    public int StartBullets3 = 10;
    [SerializeField]
    public int StartBullets4 = 10;
    [SerializeField]
    public int StartBullets5 = 10;
    [SerializeField]
    public float FinishHP = 100;
    [SerializeField]
    public int FinishCoins = 15;
    [SerializeField]
    public int FinishBullets = 0;
    [SerializeField]
    public int FinishFields = 2;
    [SerializeField]
    public int Startmonsters = 0;
    [SerializeField]
    public int Startjumps = 200;
    public static int Srespawns;
    public static int Smonsterskills;
    public static int Sjumps;
    public static int stcoins;
    public static int stbullets;
    public static int stmonsters;
    public static int stjumps;
    public static int stfields;
    void Start () {
        stcoins = StartCoins;
        stmonsters = Startmonsters;
        stjumps = Startjumps;
        Hero.heart = StartHP;
        Hero.coins = StartCoins;
        Srespawns = Global.respawns;
        Smonsterskills = Global.monsterskill;
        Sjumps = Global.jumps;
        switch (Global.difficulty)
        {
            case 1:
                Hero.bullets = StartBullets1;
                stbullets = StartBullets1;
                Hero.fields = StartFields1;
                stfields = StartFields1;
                break;
            case 2:
                Hero.bullets = StartBullets2;
                stbullets = StartBullets2;
                Hero.fields = StartFields2;
                stfields = StartFields2;
                break;
            case 3:
                Hero.bullets = StartBullets3;
                stbullets = StartBullets3;
                Hero.fields = StartFields3;
                stfields = StartFields3;
                break;
            case 4:
                Hero.bullets = StartBullets4;
                stbullets = StartBullets4;
                Hero.fields = StartFields4;
                stfields = StartFields4;
                break;
            case 5:
                Hero.bullets = StartBullets5;
                stbullets = StartBullets5;
                Hero.fields = StartFields5;
                stfields = StartFields5;
                break;
            default:
                Hero.bullets = 2;
                break;
        }
	}
}
