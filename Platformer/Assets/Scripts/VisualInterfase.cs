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
    private Text speed;
    [SerializeField]
    private Text bulletspeed;
    private void Update()
    {
        bulletspeed.text = Convert.ToString(Hero.bulletspeed) + " - bulletspeed";
        speed.text = Convert.ToString(Hero.speed) + " - speed";
        moneys.text = Convert.ToString(Hero.coins);
        Bullets.text = Convert.ToString(Hero.bullets);
        HP.transform.localScale = new Vector3(Hero.heart/100,1f,1f);
    }
}
