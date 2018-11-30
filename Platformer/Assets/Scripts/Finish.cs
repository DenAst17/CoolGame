using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {
    [SerializeField]
    GameObject finish;
    [SerializeField]
    GameObject st1;
    [SerializeField]
    GameObject st2;
    [SerializeField]
    GameObject st3;
    [SerializeField]
    Image star1;
    [SerializeField]
    Image star2;
    [SerializeField]
    Image star3;
    [SerializeField]
    GameObject fc;
    [SerializeField]
    Text FoundCoins;
    [SerializeField]
    GameObject hs;
    [SerializeField]
    Text Healthsaved;
    [SerializeField]
    GameObject dt;
    [SerializeField]
    Text Damagetaken;
    [SerializeField]
    GameObject bu;
    [SerializeField]
    Text Bulletsused;
    [SerializeField]
    GameObject gs;
    [SerializeField]
    Text Globalscore;
    private void Awake()
    {
        finish = Resources.Load("WinSheet") as GameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player" && FindObjectOfType<LevelProporties>() && !GameObject.FindGameObjectWithTag("WinSheet"))
        {
            Hero.win = true;
            Canvas ca = FindObjectOfType<Canvas>();
            Instantiate(finish, ca.transform);
            LevelProporties lp = FindObjectOfType<LevelProporties>();
            st1 = GameObject.FindGameObjectWithTag("Star1");
            star1 = st1.GetComponent<Image>();
            st2 = GameObject.FindGameObjectWithTag("Star2");
            star2 = st2.GetComponent<Image>();
            st3 = GameObject.FindGameObjectWithTag("Star3");
            star3 = st3.GetComponent<Image>();
            fc = GameObject.FindGameObjectWithTag("FoundCoins");
            FoundCoins = fc.GetComponent<Text>();
            hs = GameObject.FindGameObjectWithTag("Healthsaved");
            Healthsaved = hs.GetComponent<Text>();
            dt = GameObject.FindGameObjectWithTag("Damagetaken");
            Damagetaken = dt.GetComponent<Text>();
            bu = GameObject.FindGameObjectWithTag("Bulletsused");
            Bulletsused = bu.GetComponent<Text>();
            gs = GameObject.FindGameObjectWithTag("Globalscore");
            Globalscore = gs.GetComponent<Text>();
            FoundCoins.text = "Found coins: " + Hero.coins;
            Healthsaved.text = "Health saved: " + Hero.heart;
            Damagetaken.text = "Damage taken: " + Hero.damtaken;
            Bulletsused.text = "Bullets used: " + Hero.buluse;
            Globalscore.text = "Global score: 0";
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            if (Hero.heart <= 100) { star1.enabled = true; }
            if (Hero.heart >= 50) { star2.enabled = true; }
            if (Hero.heart >= 90) { star3.enabled = true; }
            Hero.anim.SetInteger("State", 0);
        }
        else
        {
            //SceneManager.LoadScene("SelectLevel");
        }
    }
}
