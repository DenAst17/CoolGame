using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigrockmonster : MonoBehaviour {
    [SerializeField]
    public float HP = 50;
    [SerializeField]
    public float damage = 20;
    [SerializeField]
    public float Impulse = 4000;
    public float timer = 0.9f;
    public bool kol = false;
    Animator anim;
    Rigidbody2D rb;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update () {
        if (HP<=0)
        {
            Destroy(this.gameObject);
        }
        if (kol)
        {
            if (timer <= 0)
            {
                kol = false;
            }
            timer -= Time.deltaTime;
        }
        else
        {
            anim.SetInteger("State", 0);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            anim.SetInteger("State", 1);
            kol = true;
            timer = 0.9f;
            HP -= 20;
            rb.AddForce(transform.up * Impulse, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
    }
}
