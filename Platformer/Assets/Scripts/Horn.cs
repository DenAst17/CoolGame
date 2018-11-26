using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Horn : MonoBehaviour {
    private SpriteRenderer sp;
    [SerializeField]
    private string fi = "Right";
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float hi = 0;
    [SerializeField]
    private float p = 65;
    [SerializeField]
    private float damage = 20;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Hero.heart -= damage;
            Hero.takedamage(p);
        }
    }
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        hi = UnityEngine.Random.Range(0,360);
    }
    void Update () {
        hi += UnityEngine.Random.Range(0.01f, 0.04f);
        transform.position = new Vector3(transform.position.x, transform.position.y + (float)Math.Sin(hi * Math.PI * 1.5) / -100, transform.position.z);
        if (fi == "Right")
        {
            transform.position += Vector3.right * speed;
            sp.flipX = true;
        }
        else
        {
            transform.position += Vector3.left * speed;
            sp.flipX = false;
        }
        if (fi == "Right")
        {
            if (Rightup() == true || Rightdown() == false)
            {
                fi = "Left";
            }
        }
        else
        {
            if (Leftup() == true || Leftdown() == false)
            {
                fi = "Right";
            }
        }
    }
    private bool Rightup()
    {
        int j = 0;
        Vector2 kol = transform.position; kol.x += 0.5f;
        Vector2 dol; dol.x = 0.7f; dol.y = 0.2f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(kol, 0.2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Solid")
            {
                j++;
            }
        }
        if (j > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool Leftup()
    {
        int j = 0;
        Vector2 kol = transform.position; kol.x -= 0.5f;
        Vector2 dol; dol.x = 0.7f; dol.y = 0.2f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(kol, 0.2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Solid")
            {
                j++;
            }
        }
        if (j > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool Leftdown()
    {
        int j = 0;
        Vector2 kol = transform.position; kol.x -= 0.5f; kol.y -= 1.5f;
        Vector2 dol; dol.x = 0.7f; dol.y = 0.2f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(kol, 0.2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Solid")
            {
                j++;
            }
        }
        if (j > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool Rightdown()
    {
        int j = 0;
        Vector2 kol = transform.position; kol.x += 0.5f; kol.y -= 1.5f;
        Vector2 dol; dol.x = 0.7f; dol.y = 0.2f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(kol, 0.2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Solid")
            {
                j++;
            }
        }
        if (j > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
