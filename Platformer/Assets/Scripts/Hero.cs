using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Hero : MonoBehaviour {
    [SerializeField]
    public static float heart = 100f;
    [SerializeField]
    public float speed = 300.0f;
    [SerializeField]
    public static float angle = 0f;
    public float jumpForse = 30.0f;
    public int jumps = 0;
    [SerializeField]
    public static int coins = 0;
    [SerializeField]
    private Rigidbody2D bulletblue;
    [SerializeField]
    private Rigidbody2D bulletgreen;
    [SerializeField]
    private Rigidbody2D bulletred;
    public static string colorbutton = "blue";
    public static int CoinsBoost = 1;
    public static float bulletspeed = 20f;
    public static int bullets = 30;
    public static float timetodestroybullet = 30;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sp;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        Vector3 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position.y + 0.7f < m.y)
        {
            if (m.x < transform.position.x + 0.5 && m.x > transform.position.x - 0.5)
            {
                angle = 90;
            }
            else if(m.x > transform.position.x + 0.5)
            {
                angle = (float)(180 / Math.PI) * (float)(Math.Atan(Math.Abs(m.y - (transform.position.y + 0.7)) / Math.Abs((transform.position.x + 0.5) - m.x)));
            }
            else if (m.x < transform.position.x - 0.5)
            {
                angle = (float)(180 / Math.PI) * (float)(Math.Atan(Math.Abs(m.y - (transform.position.y + 0.7)) / Math.Abs((transform.position.x - 0.5) - m.x)));
            }
        }
        else
        {
            angle = 0;
        }
        if (Input.GetKeyDown(KeyCode.E) && bullets > 0)
        {
            if (m.x < transform.position.x)
            {
                sp.flipX = true;
            }
            else { sp.flipX = false; }
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) {
            if (isGround() == 0)
            {
                if (jumps < 2)
                {
                    Jump();
                    jumps++;
                }
            }
            else
            {
                jumps = 0;
                Jump();
                jumps++;
            }
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetInteger("State", 0);
        }
        else
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                sp.flipX = true;
            }
            else
            {
                sp.flipX = false;
            }
            anim.SetInteger("State", 1);
        }
        if (rb.velocity.y > 0.2)
        {
            anim.SetInteger("State", 2);
        }
        else if (rb.velocity.y < -0.2)
        {
            anim.SetInteger("State", 3);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, rb.velocity.y);
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
    }
    private void Shoot()
    {
        Vector3 poz = transform.position; poz.y += 0.7f; poz.x += sp.flipX ? -0.5f : 0.7f;
        if (colorbutton == "blue")
        {
            Rigidbody2D clone = Instantiate(bulletblue, poz, transform.rotation) as Rigidbody2D;
            Vector3 v = new Vector3((float)Math.Cos((angle / 180.0f) * Math.PI) * (sp.flipX ? -1 : 1), (float)Math.Sin((angle / 180.0f) * Math.PI), 0);
            clone.velocity = transform.TransformDirection(v * bulletspeed);
            bullets--;
        }
        else if (colorbutton == "green")
        {
            Rigidbody2D clone = Instantiate(bulletgreen, poz, transform.rotation) as Rigidbody2D;
            Vector3 v = new Vector3((float)Math.Cos((angle / 180.0f) * Math.PI) * (sp.flipX ? -1 : 1), (float)Math.Sin((angle / 180.0f) * Math.PI), 0);
            clone.velocity = transform.TransformDirection(v * bulletspeed);
            bullets--;
        }
        else
        {
            Rigidbody2D clone = Instantiate(bulletred, poz, transform.rotation) as Rigidbody2D;
            Vector3 v = new Vector3((float)Math.Cos((angle / 180.0f) * Math.PI) * (sp.flipX ? -1 : 1), (float)Math.Sin((angle / 180.0f) * Math.PI), 0);
            clone.velocity = transform.TransformDirection(v * bulletspeed);
            bullets--;
        }
    }
    private int isGround()
    {
        int j = 0;
        Vector2 kol = transform.position; kol.x += 0.05f; kol.y += -0.1f;
        Vector2 dol; dol.x = 0.7f; dol.y = 0.2f;
        Collider2D[] colliders = Physics2D.OverlapCapsuleAll(kol, dol, CapsuleDirection2D.Horizontal, 0);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Solid" || colliders[i].gameObject.tag == "bullet")
            {
                j++;
            }
        }
        if (j > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
