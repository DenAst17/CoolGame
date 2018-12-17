using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiky_orange : MonoBehaviour
{
    [SerializeField]
    private int imp = 100;
    [SerializeField]
    private bool Easter_lvl;
    private int damage;
    private void Awake()
    {
        if (Easter_lvl)
            damage = 100;
        else
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            Hero.HaveDamage(damage);
            Hero.HaveImpulse(imp);
        }
    }
}
