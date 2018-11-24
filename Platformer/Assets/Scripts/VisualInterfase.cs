using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class VisualInterfase : MonoBehaviour {

    [SerializeField]
    private Text moneys;
    [SerializeField]
    private Text Bullets;
    [SerializeField]
    private Image HP;
    [SerializeField]
    private Image charge;
    [SerializeField]
    private Image chargef;
    [SerializeField]
    private Image fon;
    private void Update()
    {
        if (Hero.diley < 0)
        {
            chargef.color = Color.white;
        }
        else
        {
            chargef.color = Color.red;
        }
        charge.transform.localScale = new Vector3(Hero.bulletspeed/25,1,1);
        moneys.text = Convert.ToString(Hero.coins);
        Bullets.text = Convert.ToString(Hero.bullets);
        HP.transform.localScale = new Vector3(Hero.heart/100,1f,1f);
    }
}
