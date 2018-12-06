using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiky_green : MonoBehaviour
{
    private int damage;
    SpriteRenderer sp;

    [SerializeField]
    private bool b = true;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private Vector3 point1;
    [SerializeField]
    private Vector3 point2;
    [SerializeField]
    private float time = 5;
    [SerializeField]
    private float time1 = 5;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Time.timeScale != 0)
        {
            time1 -= Time.deltaTime;
            if (time1 <= 0)
            {
                if (b)
                {
                    b = false;
                    sp.flipX = false;
                }
                else
                {
                    b = true;
                    sp.flipX = true;
                }
                time1 = time;
            }
            if (b)
                transform.position = Vector3.Lerp(transform.position, point2, speed * Time.deltaTime);
            else
                transform.position = Vector3.Lerp(transform.position, point1, speed * Time.deltaTime);
        }
        
    }
    private void Start()
    {
        switch (Global.difficulty)
        {
            case 1:
                damage = 15;
                break;
            case 2:
                damage = 20;
                break;
            case 3:
                damage = 25;
                break;
            case 4:
                damage = 30;
                break;
            case 5:
                damage = 35;
                break;
        }
        transform.position = point1;
        b = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Hero.HaveDamage(damage);
            Hero.HaveImpulse(100);
        }
    }
}
