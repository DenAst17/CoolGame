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
    private Text HPtext;
    [SerializeField]
    private Text speed;
    [SerializeField]
    private Text angle;
    [SerializeField]
    private Text colorbutton;
    [SerializeField]
    private Text bulletspeed;
    private void Update()
    {
        HPtext.text = "Health " + Convert.ToString((100 * Hero.heart) / Hero.MaxHP) + "%";
        bulletspeed.text = Convert.ToString(Hero.bulletspeed) + " - bulletspeed";
        colorbutton.text = Hero.colorbutton + " - colorbutton";
        angle.text = Convert.ToString(Hero.angle) + " - angle";
        speed.text = Convert.ToString(Hero.speed) + " - speed";
        moneys.text = Convert.ToString(Hero.coins);
        Bullets.text = Convert.ToString(Hero.bullets);
        HP.transform.localScale = new Vector3((4f/100f)*Hero.heart,0.3f,1f);
    }
}
