using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    public static int cost = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "player")
        {
            Hero.coins += cost;
            GameObject.Destroy(this);
        }
    }
}
