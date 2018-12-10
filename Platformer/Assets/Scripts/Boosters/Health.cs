using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float healthup = 25;
    [SerializeField]
    private string rez = "Gold";
    private float time = 0.016f;
    Animator an;
    private void Awake()
    {
        an = GetComponent<Animator>();
        switch (rez)
        {
            case "Gold":
                an.SetInteger("State", 0);
                break;
            case "Bronze":
                an.SetInteger("State", 1);
                break;
            case "Silver":
                an.SetInteger("State", 2);
                break;
            default:
                an.SetInteger("State", 0);
                break;
        }
    }
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            time += 0.0155f;
            transform.position = new Vector3(transform.position.x, transform.position.y + (float)Math.Sin(time * Math.PI * 1.5) / -100, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Global.hpplus++;
            if (Hero.heart + healthup >= 100)
            {
                Hero.heart = 100;
            }
            else
            {
                Hero.heart += healthup;
            }
            GameObject.Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "bullet")
        {
            Global.hpplus++;
            if (Hero.heart + healthup/2 >= 100)
            {
                Hero.heart = 100;
            }
            else
            {
                Hero.heart += healthup/2;
            }
            GameObject.Destroy(this.gameObject);
        }
    }
}