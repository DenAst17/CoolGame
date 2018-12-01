using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDMG : MonoBehaviour {
    [SerializeField]
    private int damage = 30;
    public bool take = false;
    public bool fall = false;
    Animator an;
    private void Awake()
    {
        an = GetComponent<Animator>();
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
