﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullObstracle : MonoBehaviour {
    [SerializeField]
    private int damage = 20;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Hero.HaveDamage(damage);
        }
    }
}
