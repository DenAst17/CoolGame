using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Hero : MonoBehaviour {

    [SerializeField]
    float speed = 14.0f;
    [SerializeField]
    float jumpForse = 30.0f;

    Rigidbody2D rb;
    Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown (KeyCode.W)) {
            Jump();
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
}
