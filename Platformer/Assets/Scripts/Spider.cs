using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {
    [SerializeField]
    private int damage = 20;
    [SerializeField]
    private float Impulse = 10;
    private bool dir = true;
    [SerializeField]
    private float time = 0;
    [SerializeField]
    public int difficult = 2;
    [SerializeField]
    private float n = 8;
    [SerializeField]

    private float m = 15;
    Rigidbody2D rb;
    private void Start()
    {
        difficult = Global.difficulty;
        if (difficult == 1)
        {
            n = 6; m = 9; Impulse = 15;
            damage = 15;
        }
        else if (difficult == 2)
        {
            n = 5; m = 8; Impulse = 17;
            damage = 18;
        }
        else if (difficult == 3)
        {
            n = 4; m = 7; Impulse = 19;
            damage = 21;
        }
        else if (difficult == 4)
        {
            n = 3; m = 6; Impulse = 21;
            damage = 24;
        }
        else if (difficult == 5)
        {
            n = 2; m = 5; Impulse = 26;
            damage = 30;
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = Random.Range(n,m);
            rb.AddForce(new Vector2((Random.value + 0.2f) * Random.Range(-1,1), Random.value+ 0.2f * Random.Range(-1, 1)) * Impulse, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Hero.HaveDamage(damage);
        }
    }
}
