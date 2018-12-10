using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class VisualInterfase : MonoBehaviour {
    private GameObject moneys;
    private Text mon;
    private GameObject Bullets;
    private Text Bull;
    private GameObject Helsh;
    private Image HP;
    private GameObject Chargen;
    private Image charge;
    private GameObject chargefl;
    private Image chargef;
    private GameObject fi1;
    private Image f1;
    private GameObject fi2;
    private Image f2;
    private GameObject fi3;
    private Image f3;
    private GameObject fi4;
    private Image f4;
    private GameObject fi5;
    private Image f5;
    private void Start()
    {
        moneys = GameObject.FindGameObjectWithTag("MoneysCount");
        mon = moneys.GetComponent<Text>();
        Bullets = GameObject.FindGameObjectWithTag("BulletsCount");
        Bull = Bullets.GetComponent<Text>();
        Helsh = GameObject.FindGameObjectWithTag("VisualHP");
        HP = Helsh.GetComponent<Image>();
        Chargen = GameObject.FindGameObjectWithTag("Charge");
        charge = Chargen.GetComponent<Image>();
        chargefl = GameObject.FindGameObjectWithTag("BackCharge");
        chargef = chargefl.GetComponent<Image>();
        fi1 = GameObject.FindGameObjectWithTag("f1");
        f1 = fi1.GetComponent<Image>();
        fi2 = GameObject.FindGameObjectWithTag("f2");
        f2 = fi2.GetComponent<Image>();
        fi3 = GameObject.FindGameObjectWithTag("f3");
        f3 = fi3.GetComponent<Image>();
        fi4 = GameObject.FindGameObjectWithTag("f4");
        f4 = fi4.GetComponent<Image>();
        fi5 = GameObject.FindGameObjectWithTag("f5");
        f5 = fi5.GetComponent<Image>();
    }
    private void Update()
    {
        if (Hero.diley <= 0)
        {
            chargef.color = Color.white;
        }
        else
        {
            chargef.color = Color.red;
        }
        charge.transform.localScale = new Vector3(Hero.bulletspeed/25,1,1);
        mon.text = Convert.ToString(Hero.coins);
        Bull.text = Convert.ToString(Hero.bullets);
        HP.transform.localScale = new Vector3(Hero.heart/100,1f,1f);
        if (Hero.fields >= 1) f1.enabled = true;
        else if (Hero.fields < 1) f1.enabled = false;
        if (Hero.fields >= 2) f2.enabled = true;
        else if (Hero.fields < 2) f2.enabled = false;
        if (Hero.fields >= 3) f3.enabled = true;
        else if (Hero.fields < 3) f3.enabled = false;
        if (Hero.fields >= 4) f4.enabled = true;
        else if (Hero.fields < 4) f4.enabled = false;
        if (Hero.fields >= 5) f5.enabled = true;
        else if (Hero.fields < 5) f5.enabled = false;
    }
}
