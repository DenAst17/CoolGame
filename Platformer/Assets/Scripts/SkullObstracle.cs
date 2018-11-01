using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullObstracle : MonoBehaviour {
    [SerializeField]
    private float p = 65;
    [SerializeField]
    private float dmg = 20;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Hero.heart -= dmg;
            Hero.takedamage(p);
        }
    }
}
