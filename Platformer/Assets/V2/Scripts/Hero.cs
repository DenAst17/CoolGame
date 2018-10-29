using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Hero : MonoBehaviour {
    [SerializeField]
    public float heart = 100;
    [SerializeField]
    public float speed = 14.0f;
    [SerializeField]
    public float jumpForse = 30.0f;
    [SerializeField]
    public int jumps = 0;
    [SerializeField]
    public static int coins = 0;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sp;
    GameObject Spriteheart;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sp = GetComponentInChildren<SpriteRenderer>();
        Spriteheart = GameObject.FindWithTag("Heart");
    }
    private void Update()
    {
        if (Input.GetKeyDown (KeyCode.W)) {
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
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
    }
    private int isGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        if (colliders.Length > 1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}