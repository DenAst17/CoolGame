using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDMG : MonoBehaviour {
    private int damage = 30;
    public bool take = false;
    public bool fall = false;
    Animator an;
    private void Awake()
    {
        an = GetComponent<Animator>();
    }
    private void Start()
    {
        switch (Global.difficulty)
        {
            case 1:
                damage = 6;
                break;
            case 2:
                damage = 7;
                break;
            case 3:
                damage = 9;
                break;
            case 4:
                damage = 10;
                break;
            case 5:
                damage = 12;
                break;
            default:
                damage = 8;
                break;
        }
    }
    private void Update()
    {
        if (take)
        {
            Hero.HaveDamage(damage);
            take = false;
        }
        if (fall)
        {
            GameObject.Destroy(GetComponentInParent<GameObject>());
            fall = false;
        }
    }
}
