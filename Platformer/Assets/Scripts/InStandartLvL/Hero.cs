﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour {
    public static float heart = 100f;
    public static float speed = 300.0f;
    public static bool win = false;
    public static int damtaken = 0;
    public static int buluse = 0;
    [SerializeField]
    public float angle = 0f;
    [SerializeField]
    public float jumpForse = 30.0f;
    [SerializeField]
    public int jumps = 0;
    public static int coins = 0;
    [SerializeField]
    private Rigidbody2D bulletblue;
    [SerializeField]
    private Rigidbody2D bulletgreen;
    [SerializeField]
    private Rigidbody2D bulletred;
    public static int fields = 3;
    public static int stars = 0;
    public static string colorbutton = "blue";
    public static int CoinsBoost = 1;
    public static float bulletspeed = 0f;
    public static int bullets = 30;
    public static float timetodestroybullet = 30;
    public static float MaxHP = 100f;
    public static float prom = 0;
    public static float promtime = 0;
    public static bool lop = false;
    public static Rigidbody2D rb;
    public static float diley = 0;
    public static Transform tr;
    private GameObject set;
    private GameObject canvas;
    private GameObject camera;
    private GameObject visual;
    private GameObject eventsystem;
    public static Animator anim;
    private GameObject hug;
    SpriteRenderer sp;
    private void Start()
    {
        Time.timeScale = 1;
        win = false;
        damtaken = 0;
        buluse = 0;
        colorbutton = "blue";
        if (!FindObjectOfType<Camera>()) {
            GameObject clone1 = Instantiate(camera);
            CameraController cc = clone1.GetComponent<CameraController>();
            cc.target = this.transform;
            GameObject clone2 = Instantiate(canvas);
            Canvas cv = clone2.GetComponent<Canvas>();
            cv.renderMode = RenderMode.ScreenSpaceCamera;
            cv.worldCamera = clone1.GetComponent<Camera>();
            Instantiate(visual);
            Instantiate(eventsystem);
        }
    }
    private void Awake()
    {

        set = Resources.Load("Pause") as GameObject;
        hug = Resources.Load("Hug") as GameObject;
        canvas = Resources.Load("Canvas") as GameObject;
        camera = Resources.Load("Main Camera") as GameObject;
        visual = Resources.Load("Visual") as GameObject;
        eventsystem = Resources.Load("EventSystem") as GameObject;
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if (!win)
        {
            if (heart <= 0)
            {
                Global.deads++;
                heart = 100;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                heart = 100;
            }
            if (Input.GetKeyDown(KeyCode.Escape) && !GameObject.FindGameObjectWithTag("Pause"))
            {
                Time.timeScale = 0;
                Canvas ca = FindObjectOfType<Canvas>();
                Instantiate(hug,ca.transform);
                Instantiate(set, ca.transform);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("Pause"))
            {
                Time.timeScale = 1;
                Destroy(GameObject.FindGameObjectWithTag("Pause"));
                Destroy(GameObject.FindGameObjectWithTag("hug"));
            }
            if (diley > -10) diley -= Time.deltaTime;
            if (diley < 0)
            {
                if (Input.GetKey(KeyCode.Space) && bulletspeed < 25 && bullets > 0) { bulletspeed += 0.7f; }
                if (Input.GetKey(KeyCode.Space) && angle < 45 && bullets > 0) { angle += 0.4f; };
                if (Input.GetKeyUp(KeyCode.Space) && bullets > 0)
                {
                    Shoot();
                    buluse++;
                    Global.shoots++;
                }
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isGround() == true)
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
            if (rb.velocity.y > 0 && isGround() == true)
            {
                anim.SetInteger("State", 2);
            }
            else if (rb.velocity.y < 0 && isGround() == true)
            {
                anim.SetInteger("State", 3);
            }
        }
    }
    public static void HaveDamage(int dam)
    {
        if (!win) {
            if (fields <= 0)
            {
                heart -= dam;
                damtaken += dam;
            }
            else
            {
                fields--;
            }
        }
    }
    void FixedUpdate()
    {
        if (!win)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, rb.velocity.y);
        }
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
    }
    private void Shoot()
    {
        Vector3 poz = transform.position; poz.y += 0.7f; poz.x += sp.flipX ? -0.5f : 0.7f;poz.z = 0;
        if (colorbutton == "blue")
        {
            Rigidbody2D clone = Instantiate(bulletblue, poz, transform.rotation) as Rigidbody2D;
            Vector3 v = new Vector3((float)Math.Cos((angle / 180.0f) * Math.PI) * (sp.flipX ? -1 : 1), (float)Math.Sin((angle / 180.0f) * Math.PI), 0);
            clone.velocity = transform.TransformDirection(v * bulletspeed);
            bullets--;
            bulletspeed = 0;
            angle = 0;
            diley = 2;
        }
        else if (colorbutton == "green")
        {
            Rigidbody2D clone = Instantiate(bulletgreen, poz, transform.rotation) as Rigidbody2D;
            Vector3 v = new Vector3((float)Math.Cos((angle / 180.0f) * Math.PI) * (sp.flipX ? -1 : 1), (float)Math.Sin((angle / 180.0f) * Math.PI), 0);
            clone.velocity = transform.TransformDirection(v * bulletspeed);
            bullets--;
            bulletspeed = 0;
            angle = 0;
            diley = 2;
        }
        else
        {
            Rigidbody2D clone = Instantiate(bulletred, poz, transform.rotation) as Rigidbody2D;
            Vector3 v = new Vector3((float)Math.Cos((angle / 180.0f) * Math.PI) * (sp.flipX ? -1 : 1), (float)Math.Sin((angle / 180.0f) * Math.PI), 0);
            clone.velocity = transform.TransformDirection(v * bulletspeed);
            bullets--;
            bulletspeed = 0;
            angle = 0;
            diley = 2;
        }
    }
    private bool isGround()
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
            return false;
        }
        else
        {
            return true;
        }
    }
    public static void HaveImpulse(float n)
    {
        rb.AddForce(Vector2.up * n, ForceMode2D.Impulse);
    }
}
