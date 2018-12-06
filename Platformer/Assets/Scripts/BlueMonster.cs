using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonster : MonoBehaviour {
    Animator an;
    Rigidbody2D rb;
    SpriteRenderer sp;
    private int damage;
    private bool touch = true;
    private string dir = "Right";
    private float JumpImpuls = 35;
    [SerializeField]
    private float JumpImpulsel = 30;
    [SerializeField]
    private float JumpImpulser = 40;
    private void Start()
    {
        switch (Global.difficulty)
        {
            case 1:
                damage = 7;
                break;
            case 2:
                damage = 9;
                break;
            case 3:
                damage = 11;
                break;
            case 4:
                damage = 13;
                break;
            case 5:
                damage = 15;
                break;
        }
    }
    private void Awake()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        an.SetInteger("State", 1);
    }
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Rightdown() == false && Leftdown() == false)
            {
                touch = false;
            }
            if (dir == "Right" && touch == true)
            {
                JumpImpuls = Random.Range(JumpImpulsel, JumpImpulser);
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(1,1) * JumpImpuls,ForceMode2D.Impulse);
                sp.flipX = true;
            }
            else if(touch == true)
            {
                JumpImpuls = Random.Range(JumpImpulsel, JumpImpulser);
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(-1, 1) * JumpImpuls, ForceMode2D.Impulse);
                sp.flipX = false;
            }
            if (dir == "Right")
            {
                if (Rightup() == true || Rightdown() == false)
                {
                    dir = "Right";
                }
            }
            else
            {
                if (Leftup() == true || Leftdown() == false)
                {
                    dir = "Left";
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.timeScale != 0)
        {
            if (collision.gameObject.tag == "Solid")
            {
                touch = true;
            }
            if (collision.gameObject.tag == "Monster")
            {
                if (dir == "Right") { dir = "Left"; }
                if (dir == "Left") { dir = "Right"; }
            }
        }
        if (collision.gameObject.tag == "player")
        {
            Hero.HaveDamage(damage);
            Hero.HaveImpulse(100);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            if (dir == "Right") { dir = "Left"; }
            if (dir == "Left") { dir = "Right"; }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Kokol")
        {
            if (dir == "Right")
            {
                dir = "Left";
                JumpImpuls = Random.Range(JumpImpulsel, JumpImpulser);
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(-1, 1) * JumpImpuls, ForceMode2D.Impulse);
                sp.flipX = !sp.flipX;
            }
            else if (dir == "Left")
            {
                dir = "Right";
                JumpImpuls = Random.Range(JumpImpulsel, JumpImpulser);
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(1, 1) * JumpImpuls, ForceMode2D.Impulse);
                sp.flipX = !sp.flipX;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Time.timeScale != 0)
        {
            if (collision.gameObject.tag == "Solid")
            {
                touch = false;
            }
        }
    }
    private bool Rightup()
    {
        int j = 0;
        Vector2 kol = transform.position; kol.x += 0.5f;
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
        Vector2 kol = transform.position; kol.x -= 2f; kol.y -= 1f;
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
        Vector2 kol = transform.position; kol.x += 2f; kol.y -= 1f;
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
