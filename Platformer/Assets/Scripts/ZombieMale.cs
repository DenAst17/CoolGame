using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMale : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private string fi = "Left";
    private float speed = 0.04f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        anim.SetInteger("State", 1);
        if (fi == "Right")
        {
            transform.position += Vector3.right * speed;
            sp.flipX = false;
        }
        else
        {
            transform.position += Vector3.left * speed;
            sp.flipX = true;
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
