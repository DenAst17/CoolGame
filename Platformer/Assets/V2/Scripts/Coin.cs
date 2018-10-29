using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private int cost = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Yes");
        if (collision.gameObject.GetComponent<Hero>())
        {
            Hero.coins += cost;
            GameObject.Destroy(this);
        }
    }
}
