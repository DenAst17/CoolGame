using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Hero : MonoBehaviour {
    [SerializeField]
    public float heart = 100;
    [SerializeField]
    public float speed = 300.0f;
    public float jumpForse = 30.0f;
    public int jumps = 0;
    [SerializeField]
    public static int coins = 0;
    [SerializeField]
    private Rigidbody2D bullet;
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
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0) && bullets > 0)
        {
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
        Vector3 poz = transform.position; poz.y += 0.5f; poz.x += sp.flipX ? -0.5f : 0.5f;
        Rigidbody2D clone = Instantiate(bullet, poz, transform.rotation) as Rigidbody2D;
        clone.velocity = transform.TransformDirection((sp.flipX ? Vector3.left : Vector3.right) * bulletspeed);
        bullets--;
        Debug.Log("Holo");
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