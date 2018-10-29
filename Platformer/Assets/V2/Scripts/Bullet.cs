using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    public static float damage = 5.0f;
    Rigidbody2D rb;
    public static SpriteRenderer sp;
    private void Awake()
    { 
        sp = GetComponentInChildren<SpriteRenderer>();
    }

}
