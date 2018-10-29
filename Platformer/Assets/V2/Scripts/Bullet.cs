using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void Start()
    {
        Destroy(gameObject, Hero.timetodestroybullet);
    }
}
