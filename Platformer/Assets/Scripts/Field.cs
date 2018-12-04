using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Field : MonoBehaviour {
    [SerializeField]
    private int fieldspl = 1;
    private float time = 0.016f;
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            time += 0.0155f;
            transform.position = new Vector3(transform.position.x, transform.position.y + (float)Math.Sin(time * Math.PI * 1.5) / -100, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Global.fieldsplus++;
            if (Hero.fields + fieldspl >= 5)
            {
                Hero.fields = 5;
            }
            else
            {
                Hero.fields += fieldspl;
            }
            GameObject.Destroy(this.gameObject);
        }
    }
}
