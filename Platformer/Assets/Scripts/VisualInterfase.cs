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
    private void Update()
    {
        moneys.text = Convert.ToString(Hero.coins);
        Bullets.text = Convert.ToString(Hero.bullets);
        HP.transform.localScale = new Vector3((4f/100f)*Hero.heart,0.3f,1f);
    }
}
