using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    public static float speed= 300.0f;
    [SerializeField]
    public static float damage = 5.0f;

    public static float dir = 1.0f;
    Rigidbody2D rb;
    public static SpriteRenderer sp;
    public static bool ji = false;
    public static bool cr = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if (ji)
        {
            if (!cr)
            {
                Started(Hero.dir);
                cr = true;
            }
        }
    }
    public static void Started(bool dira)
    {
        Debug.Log(dira);
        Debug.Log(dir);
        dir = dira ? -1 : 1;
        sp.flipX = Hero.dir;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dir * speed * Time.deltaTime, rb.velocity.y);
    }
}
