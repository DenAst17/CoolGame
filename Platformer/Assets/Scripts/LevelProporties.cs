using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProporties : MonoBehaviour {
    [SerializeField]
    public Vector3 StartPozition;
    [SerializeField]
    public int Level = 1;
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
    void Start () {
        Hero.heart = StartHP;
        Hero.coins = StartCoins;
        switch (Global.difficulty)
        {
            case 1:
                Hero.bullets = StartBullets1;
                Hero.fields = StartFields1;
                break;
            case 2:
                Hero.bullets = StartBullets2;
                Hero.fields = StartFields2;
                break;
            case 3:
                Hero.bullets = StartBullets3;
                Hero.fields = StartFields3;
                break;
            case 4:
                Hero.bullets = StartBullets4;
                Hero.fields = StartFields4;
                break;
            case 5:
                Hero.bullets = StartBullets5;
                Hero.fields = StartFields5;
                break;
            default:
                Hero.bullets = 2;
                break;
        }
	}
}
