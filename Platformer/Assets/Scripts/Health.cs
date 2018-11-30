using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float healthup = 25;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (float)Math.Sin(Time.time * Math.PI * 1.5) / -100, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
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