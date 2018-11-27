using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {
    [SerializeField]
    private float damage = 20;
    [SerializeField]
    private float Impulse = 10;
    private bool dir = true;
    [SerializeField]
    private float time = 10;
    [SerializeField]
    public int difficult = 2;
    private float n = 8;
    private float m = 15;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = difficult * 10;
        if (difficult == 1) { n = 10; m = 20; Impulse = 10; }
        if (difficult == 2) { n = 10; m = 16; Impulse = 12; }
        if (difficult == 3) { n = 8; m = 14; Impulse = 14; }
        if (difficult == 4) { n = 7; m = 12; Impulse = 16; }
        if (difficult == 5) { n = 5; m = 10; Impulse = 20; }
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = Random.Range(n,m);
            if (dir)
            {
                rb.AddForce(Vector2.right * Impulse, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.left * Impulse, ForceMode2D.Impulse);
            }
            dir = Random.Range(1, 3) > 2 ? true : false; 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Hero.heart -= damage;
        }
    }
}
