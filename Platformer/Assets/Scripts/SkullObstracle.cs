using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullObstracle : MonoBehaviour {
    [SerializeField]
    private float p = 65;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Hero.heart -= 20;
            Hero.takedamage(p);
        }
    }
}
