using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Power : MonoBehaviour {
    [SerializeField]
    public static int t = 10;
    [SerializeField]
    public static int power = 50;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (float)Math.Sin(Time.time * Math.PI * 1.5) / -100, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Global.bustersplus++;
            Hero.Power(t,power);
            Destroy(this.gameObject);
        }
    }
}
