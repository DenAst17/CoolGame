using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMale : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private CapsuleCollider2D cl;
    private string fi = "Left";
    private float speed = 0.04f;
    private bool attack = false;
    private int damage = 20;
    [SerializeField]
    private bool FastZombie = true;
    [SerializeField]
    private float hp = 60;
    private bool dead = false;
    private void Awake()
    {
        cl = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        switch (Global.difficulty)
        {
            case 1:
                speed = 0.025f;
                hp = 10;
                damage = 6;
                break;
            case 2:
                speed = 0.03f;
                hp = 20;
                damage = 7;
                break;
            case 3:
                speed = 0.035f;
                hp = 30;
                damage = 9;
                break;
            case 4:
                speed = 0.04f;
                hp = 40;
                damage = 10;
                break;
            case 5:
                speed = 0.045f;
                hp = 50;
                damage = 12;
                break;
            default:
                speed = 0.06f;
                hp = 75;
                damage = 15;
                break;
        }
    }
    private void Update()
    {
        if (hp <= 0) { dead = true; Global.monsterskill++; }
        if (!dead)
        {
            cl.enabled = true;
            if (!attack)
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
            }
            else
            {
                anim.SetInteger("State", 2);
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
        else
        {
            anim.SetInteger("State", 3);
        }
    }
    private bool Rightup()
    {
        int j = 0, k = 0; 
        Vector2 kol = transform.position; kol.x += 0.5f;
        Vector2 dol; dol.x = 0.7f; dol.y = 0.2f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(kol, 0.2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Solid")
            {
                j++;
            }
            else if (colliders[i].gameObject.tag == "player")
            {
                k++;
            }
        }
        if (k >= 1) { attack = true; } else { attack = false; }
        k = 0;
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
        int j = 0, k = 0;
        Vector2 kol = transform.position; kol.x -= 0.5f;
        Vector2 dol; dol.x = 0.7f; dol.y = 0.2f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(kol, 0.2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Solid")
            {
                j++;
            }
            else if (colliders[i].gameObject.tag == "player")
            {
                k++;
            }
        }
        if (k >= 1) { attack = true; } else { attack = false; }
        k = 0;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!dead) {
            if (collision.gameObject.tag == "player")
            {
                Hero.HaveDamage(damage);
            }
            else if (collision.gameObject.tag == "bullet")
            {
                if (collision.gameObject.name == "BulletBlue(Clone)")
                {
                    BulletBlue bb = collision.gameObject.GetComponent<BulletBlue>();
                    hp -= bb.damage;
                }
                else if (collision.gameObject.name == "BulletGreen(Clone)")
                {
                    BulletGreen bb = collision.gameObject.GetComponent<BulletGreen>();
                    hp -= bb.damage;
                }
                else if (collision.gameObject.name == "BulletRed(Clone)")
                {
                    BulletRed bb = collision.gameObject.GetComponent<BulletRed>();
                    hp -= bb.damage;
                }
                GameObject.Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
