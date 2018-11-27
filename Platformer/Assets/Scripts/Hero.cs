using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour {
    public static float heart = 100f;
    public static float speed = 300.0f;
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
    Animator anim;
    SpriteRenderer sp;
    private void Awake()
    {
        set = Resources.Load("Pause") as GameObject;
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if (heart <= 0)
        {
            heart = 100;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !GameObject.FindGameObjectWithTag("Settings"))
        {
            Canvas ca = FindObjectOfType<Canvas>();
            Instantiate(set, ca.transform);
        }
        if (diley > -10)diley -= Time.deltaTime;
        if (diley < 0) {
            if (Input.GetKey(KeyCode.Space) && bulletspeed < 25) { bulletspeed += 0.7f; }
            if (Input.GetKey(KeyCode.Space) && angle < 45) { angle += 0.4f; };
            if (Input.GetKeyUp(KeyCode.Space)) { Shoot(); }
        }
        if (Input.GetKeyDown(KeyCode.W)) {
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
        if (rb.velocity.y > 0  && isGround() == true)
        {
            anim.SetInteger("State", 2);
        }
        else if (rb.velocity.y < 0  && isGround() == true)
        {
            anim.SetInteger("State", 3);
        }
        if (lop)
        {
            promtime -= Time.deltaTime;
            if (promtime <= 0)
            {
                promtime = 0;
                speed -= prom;
                lop = false;
            }
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
    public static void Power(int t, int power)
    {
        prom = power;
        promtime = t;
        lop = true;
        speed += power;
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
}
