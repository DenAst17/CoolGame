using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Horn : MonoBehaviour {
    private SpriteRenderer sp;
    [SerializeField]
    private string fi = "Right";
    [SerializeField]
    private float speed = 0.04f;
    private float hi = 0;
    [SerializeField]
    private int damage = 20;
    [SerializeField]
    public int difficulty = 2;
    public float timestan = 5;
    public float timem = 0;
    Animator an;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && timem < 0)
        {
            Hero.HaveDamage(damage);
        }
        else if (collision.gameObject.tag == "bullet" && timem < 0)
        {
            GameObject.Destroy(collision.gameObject);
            timem = timestan;
        }
    }
    private void Start()
    {
        difficulty = Global.difficulty;
        hi = UnityEngine.Random.Range(0, 360);
        if (difficulty == 1)
        {
            speed = 0.04f;
            damage = 10;
            timestan = 6;
        }
        else if (difficulty == 2)
        {
            speed = 0.045f;
            damage = 15;
            timestan = 4.5f;
        }
        else if (difficulty == 3)
        {
            speed = 0.05f;
            damage = 20;
            timestan = 4;
        }
        else if (difficulty == 4)
        {
            speed = 0.055f;
            damage = 25;
            timestan = 3;
        }
        else if (difficulty == 5)
        {
            speed = 0.06f;
            damage = 30;
            timestan = 2;
        }
    }
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
    }
    void Update() {
        if (Time.timeScale != 0) {
            if (timem > -10)
            {
                timem -= Time.deltaTime;
            }
            if (timem < 0)
            {
                an.SetInteger("State", 0);
                hi += UnityEngine.Random.Range(0.01f, 0.04f);
                transform.position = new Vector3(transform.position.x, transform.position.y + (float)Math.Sin(hi * Math.PI * 1.5) / -100, transform.position.z);
            }
            else
            {
                an.SetInteger("State", 1);
            }
            if (fi == "Right" && timem < 0)
            {
                transform.position += Vector3.right * speed;
                sp.flipX = true;
            }
            else if (timem < 0)
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
