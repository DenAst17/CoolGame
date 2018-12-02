using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    public static int cost = 5;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y+(float)Math.Sin(Time.time*Math.PI*1.5)/-100,transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Global.coinsplus+= cost * Hero.CoinsBoost;
            Hero.coins += cost*Hero.CoinsBoost;
            Destroy(this.gameObject);
        }
    }
}
